import { Component, OnInit } from '@angular/core';
import { SurveyService } from 'src/app/_services/survey.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { QuestionService } from 'src/app/_services/question.service';
import { SurveyQuestion } from 'src/app/_models/surveyQuestion';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Survey } from 'src/app/_models/survey';
import { Company } from 'src/app/_models/company';
import { SurveyProp } from 'src/app/_models/surveyprop';
import { SurveyOption } from 'src/app/_models/surveyoption';

@Component({
  selector: 'app-addsurveydata',
  templateUrl: './addsurveydata.component.html',
  styleUrls: ['./addsurveydata.component.css']
})
export class AddSurveyDataComponent implements OnInit {
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
    getCompanyDetail() {


      this.surveyService.getCompanySurvey(this.surveyprop).subscribe((company: Company) => {
        this.company = company;
        this.survey = company.surveys[0];
        this.questions = this.survey.surveyQuestions;

        this.createSurveyForm();

        this.qq = this.qs.getQuestionFormData(this.questions);

        // console.log(this.qq);

      }, error => {
        this.toastr.error(error);
      });

    }


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

}
