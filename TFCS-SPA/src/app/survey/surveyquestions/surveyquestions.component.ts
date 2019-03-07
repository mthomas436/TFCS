import { Component, OnInit, ElementRef } from '@angular/core';
import { SurveyService } from 'src/app/_services/survey.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SurveyProp } from 'src/app/_models/surveyprop';
import { Company } from 'src/app/_models/company';
import { Survey } from 'src/app/_models/survey';
import { SurveyQuestion } from 'src/app/_models/surveyQuestion';
import * as $ from 'jquery';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SurveyOption } from 'src/app/_models/surveyoption';
import { QuestionService } from 'src/app/_services/question.service';


@Component({
  selector: 'app-surveyquestions',
  templateUrl: './surveyquestions.component.html',
  styleUrls: ['./surveyquestions.component.css']
})
export class SurveyQuestionsComponent implements OnInit {

  surveyprop: SurveyProp;
  company: Company;
  survey: Survey;
  questions: SurveyQuestion[];
  result: any[];
  currentOptionType: number;
  itemsToSave: any;

  surveyForm: FormGroup;
  newQuestion: SurveyQuestion;


  qq: any[];
  constructor(private surveyService: SurveyService, private router: Router,
              private route: ActivatedRoute, private toastr: ToastrService, private qs: QuestionService) { }

  ngOnInit() {

    this.surveyprop = { companyId: 0, surveyId: 0};

    this.route.params.subscribe(params => {


      const companyId: number = +params['companyid'];
      const surveyId: number =  +params['surveyid'];

      // console.log(companyId + ' ' + surveyId);
      this.surveyprop = { companyId: companyId, surveyId: surveyId};

      this.getCompanyDetail();

    });
  }

  // ngAfterViewInit() {
  //   const elements = this.elRef.nativeElement.querySelectorAll('.surveyinput');
  //   console.log(elements);
  // }

  getCompanyDetail() {


    this.surveyService.getCompanySurvey(this.surveyprop).subscribe((company: Company) => {
      this.company = company;
      this.survey = company.surveys[0];
      this.questions = this.survey.surveyQuestions;

      // this.createSurveyForm();

      this.qq = this.qs.getQuestionFormData(this.questions);

      // console.log(this.qq);

    }, error => {
      this.toastr.error(error);
    });

  }

  submitSurvey() {
    this.itemsToSave = $('.surveyinput').serialize();

  }
/*
  createSurveyForm() {
    this.surveyForm = new FormGroup({
      companyId: new FormControl(this.surveyprop.companyId, [Validators.required, Validators.pattern('^[0-9].*$')]),
      surveyId: new FormControl(this.surveyprop.surveyId, [Validators.required, Validators.pattern('^[0-9].*$')])
    });



    this.questions.forEach((question, index) => {
      const elem: SurveyOption = question.surveyOptions[0];
      const newControl = new FormControl('', [Validators.required]);
    });


  }
*/
  // groupResults(surveyOption: SurveyOption[]) {
  //   Option.
  //   const groups = new Set(this.questions.map(item => surveyOption.questionId));
  //   this.result = [];


  //   groups.forEach( g =>
  //     this.result.push({
  //       name: g,
  //       values: this.questions.filter(i => i.questionId === g)
  //     }
  //   ));

  //   console.log(this.result);
  // }

}
