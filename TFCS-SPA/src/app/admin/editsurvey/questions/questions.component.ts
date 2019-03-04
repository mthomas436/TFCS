import { Component, OnInit } from '@angular/core';
import { Survey } from 'src/app/_models/survey';
import { SurveyProp } from 'src/app/_models/surveyprop';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {
  survey: Survey;
  surveyProp: SurveyProp;
  constructor(private adminService: AdminService, private router: Router,
              private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {

      const companyId: number = +params['companyid'];
      const surveyId: number =  +params['surveyid'];

      // console.log(companyId + ' ' + surveyId);
      this.surveyProp = { companyId: companyId, surveyId: surveyId};

      this.getSurveyQuestions();
    });


  }

  getSurveyQuestions() {
    this.adminService.getQuestions(this.surveyProp).subscribe((survey: Survey) => {
      this.survey = survey;
      console.log(this.survey);
    }, error => {
      this.toastr.error(error);
    });
  }

}
