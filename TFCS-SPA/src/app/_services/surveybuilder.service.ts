import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Company } from '../_models/company';
import { HttpClient } from '@angular/common/http';
import { Survey } from '../_models/survey';
import { SurveyProp } from '../_models/surveyprop';
import { SurveyQuestion } from '../_models/surveyQuestion';
import { SurveyOptionType } from '../_models/surveyoptiontype';
import { SurveyOption } from '../_models/surveyoption';


@Injectable({
  providedIn: 'root'
})
export class SurveyBuilderService {

  baseUrl = environment.apiUrl + 'questions/';
  companies: Company[];

  constructor(private http: HttpClient) { }

  getQuestions(surveyProp: SurveyProp): Observable<Survey> {
    return this.http.post<Survey>(this.baseUrl + 'getsurveyquestions', surveyProp);
  }

  updateQuestion(surveyQuestion: SurveyQuestion): Observable<SurveyQuestion> {
    return this.http.post<SurveyQuestion>(this.baseUrl + 'updatesurveyquestion', surveyQuestion);
  }

  addQuestion(surveyQuestion: SurveyQuestion):  Observable<SurveyQuestion> {
    return this.http.post<SurveyQuestion>(this.baseUrl + 'addsurveyquestion', surveyQuestion);
  }

  deleteQuestion(surveyQuestion: SurveyQuestion):  Observable<SurveyQuestion> {
    return this.http.post<SurveyQuestion>(this.baseUrl + 'deletequestion', surveyQuestion);
  }

  getOptionTypes(): Observable<SurveyOptionType[]> {
    return this.http.get<SurveyOptionType[]>(this.baseUrl + 'getoptiontypes');
  }

  saveOption(surveyOption: SurveyOption): Observable<SurveyOption> {
    return this.http.post<SurveyOption>(this.baseUrl + 'updateoption', surveyOption);
  }

  addOption(surveyOption: SurveyOption): Observable<SurveyOption> {
    return this.http.post<SurveyOption>(this.baseUrl + 'addoption', surveyOption);
  }

  deleteOption(surveyOption: SurveyOption): Observable<SurveyOption> {
    return this.http.post<SurveyOption>(this.baseUrl + 'deleteoption', surveyOption);
  }

  updateSurveyInfo(survey: Survey): Observable<Survey> {
    return this.http.post<Survey>(this.baseUrl + 'updatesurveyinfo', survey);
  }
}
