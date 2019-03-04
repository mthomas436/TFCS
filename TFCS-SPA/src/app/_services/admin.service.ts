import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Company } from '../_models/company';
import { HttpClient } from '@angular/common/http';
import { Survey } from '../_models/survey';
import { SurveyType } from '../_models/surveytype';
import { Role } from '../_models/role';
import { RoleToCreate } from '../_models/roletocreate';
import { User } from '../_models/user';
import { SurveyProp } from '../_models/surveyprop';
 

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  baseUrl = environment.apiUrl + 'admin/';
  companies: Company[];

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl + 'getCompanies');
  }

  getCompanyDetail(companyid: number): Observable<Company> {
    return this.http.get<Company>(this.baseUrl + 'getCompanyDetail/' + companyid);
  }

  getSurveyTypes(): Observable<SurveyType[]> {
    return this.http.get<SurveyType[]>(this.baseUrl + 'getSurveyTypes');
  }


  updateCompany(company: Company): Observable<Company> {
    return this.http.post<Company>(this.baseUrl + 'updatecompany', company);
  }


  addSurveyToCompany(survey: Survey): Observable<Company> {
    return this.http.post<Company>(this.baseUrl + 'addsurveytocompany', survey);
  }

  removeSurveyFromCompany(survey: Survey): Observable<Company> {
    return this.http.post<Company>(this.baseUrl + 'removesurveyfromcompany', survey);
  }

  createRole(roleName: RoleToCreate): Observable<Role[]> {
    return this.http.post<Role[]>(this.baseUrl + 'createrole', roleName);
  }

  getRoleList(): Observable<Role[]> {
    return this.http.get<Role[]>(this.baseUrl + 'getrolelist');
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'getuserlist');
  }

  getCompanyUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'getuserlist');
  }



  getQuestions(surveyProp: SurveyProp): Observable<Survey> {
    return this.http.post<Survey>(this.baseUrl + 'getsurveyquestions', surveyProp);
  }

}
