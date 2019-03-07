import { Component, OnInit } from '@angular/core';
import { Survey } from 'src/app/_models/survey';
import { SurveyProp } from 'src/app/_models/surveyprop';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SurveyQuestion } from 'src/app/_models/surveyQuestion';
import { SurveyBuilderService } from 'src/app/_services/surveybuilder.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {
  survey: Survey;
  surveyProp: SurveyProp;
  questionForm: FormGroup;
  displayModal: boolean;
  displayOptionModal: boolean;
  modalheader: string;
  modalMode: string;
  surveyQuestions: SurveyQuestion[];
  selectedQuestion: any;
  surveyIntro: string;
  surveyFooter: string;


  constructor(private surveyBuilderService: SurveyBuilderService, private router: Router,
              private route: ActivatedRoute, private toastr: ToastrService, private fb: FormBuilder) { }

  ngOnInit() {
    this.selectedQuestion = {};
    this.displayModal = false;
    this.displayOptionModal = false;
    this.route.params.subscribe(params => {

      const companyId: number = +params['companyid'];
      const surveyId: number =  +params['surveyid'];

      // console.log(companyId + ' ' + surveyId);
      this.surveyProp = { companyId: companyId, surveyId: surveyId};

      this.getSurveyQuestions();
    });

    this.questionForm = this.fb.group({
      'questionName': ['', Validators.required],
      'questionOrder': [0],
      'questionType': ['', Validators.required],
      'required': [true],
      'questionId': [0]
    });


  }

  getSurveyQuestions() {
    this.surveyBuilderService.getQuestions(this.surveyProp).subscribe((survey: Survey) => {
      this.survey = survey;

      this.surveyIntro = survey.surveyIntro;
      this.surveyFooter = survey.surveyFooterText;
      // Sort by questionOrder
      this.surveyQuestions = this.survey.surveyQuestions.sort( (a, b) => a.questionOrder - b.questionOrder  );

    }, error => {
      this.toastr.error(error);
    });
  }

  displayQuestion(question: SurveyQuestion) {
    this.questionForm.controls['questionName'].setValue(question.questionName);
    this.questionForm.controls['questionOrder'].setValue(question.questionOrder);
    this.questionForm.controls['questionType'].setValue(question.questionType);
    this.questionForm.controls['required'].setValue(question.required);
    this.questionForm.controls['questionId'].setValue(question.questionId);

    this.modalheader = 'Edit Question';
    this.modalMode = 'update';
    this.displayModal = true;
  }

  displayNewQuestionForm() {
    this.modalheader = 'New Question';
    this.questionForm.reset();
    this.displayModal = true;
    this.modalMode = 'new';
  }

  closeModal() {
    this.questionForm.reset();
    this.displayModal = false;
  }

  addOptions(question: SurveyQuestion) {
    this.selectedQuestion = question;
    this.displayOptionModal = true;
  }

  saveChanges() {
    const curQuestion: any = {
                                surveyId: this.survey.surveyId,
                                questionId: this.questionForm.get('questionId').value,
                                questionName: this.questionForm.get('questionName').value,
                                questionType: this.questionForm.get('questionType').value,
                                required: this.questionForm.get('required').value,
                                questionOrder: this.questionForm.get('questionOrder').value,
                                shortQuestionName: this.questionForm.get('questionName').value
                             };

    this.surveyBuilderService.updateQuestion(curQuestion).subscribe((surveyQuestion: SurveyQuestion) => {
      this.getSurveyQuestions();
      this.questionForm.reset();
      this.displayModal = false;
    }, error => {
      this.toastr.error(error);
    });
  }

  addQuestion() {
    const newQuestion: any = {
      surveyId: this.survey.surveyId,
      questionName: this.questionForm.get('questionName').value,
      questionType: this.questionForm.get('questionType').value,
      required: this.questionForm.get('required').value,
      questionOrder: this.questionForm.get('questionOrder').value,
      shortQuestionName: this.questionForm.get('questionName').value
   };

   this.surveyBuilderService.addQuestion(newQuestion).subscribe((surveyQuestion: SurveyQuestion) => {
    this.getSurveyQuestions();
    this.questionForm.reset();
    this.displayModal = false;
    }, error => {
    this.toastr.error(error);
    });
  }

  deleteQuestion(question: SurveyQuestion) {
    const curQuestion: any = {
      surveyId: question.surveyId,
      questionId: question.questionId,
      questionName: question.questionName,
      questionType: question.questionType,
      required: question.required,
      questionOrder: question.questionOrder,
      shortQuestionName: question.shortQuestionName
   };

   if (confirm('Do you really want to delete this question?') ) {
    this.surveyBuilderService.deleteQuestion(curQuestion).subscribe((surveyQuestion: SurveyQuestion) => {
      this.getSurveyQuestions();
      this.questionForm.reset();
      this.displayModal = false;
     }, error => {
      this.toastr.error(error);
     });
   }

  }

  updateSurveyInfo() {
    this.survey.surveyIntro = this.surveyIntro;
    this.survey.surveyFooterText = this.surveyFooter;

    this.surveyBuilderService.updateSurveyInfo(this.survey).subscribe((survey: Survey) => {

     }, error => {
      this.toastr.error(error);
     });
  }

  cancel() {
    this.getSurveyQuestions();
  }

}
