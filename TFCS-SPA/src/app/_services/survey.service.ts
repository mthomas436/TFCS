import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SurveyProp } from '../_models/surveyprop';
import { Company } from '../_models/company';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  baseUrl = environment.apiUrl + 'survey/';
  userId = this.authService.getUserid();

  constructor(private http: HttpClient, private authService: AuthService) { }


  getCompanySurvey(surveyProp: SurveyProp): Observable<Company> {
    return this.http.post<Company>(this.baseUrl + 'getcompanysurvey', surveyProp);
  }


}
