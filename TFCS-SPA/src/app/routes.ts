import { Routes } from '@angular/router';
 import { CompanyListComponent } from './admin/companylist/companylist.component';
import { AuthGuard } from './_guards/auth.guard';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
 import { HomeComponent } from './home/home.component';
import { EditCompanyComponent } from './admin/editcompany/editcompany.component';
import { ReportsComponent } from './reports/reports.component';
import { BadEmailsComponent } from './bademails/bademails.component';
import { RoleManagerComponent } from './admin/usermanager/rolemanager/rolemanager.component';
import { SurveyQuestionsComponent } from './survey/surveyquestions/surveyquestions.component';
import { UserListComponent } from './admin/usermanager/userlist/userlist.component';
import { EditUserComponent } from './admin/usermanager/edituser/edituser.component';
import { AddSurveyDataComponent } from './survey/addsurveydata/addsurveydata.component';
import { QuestionsComponent } from './admin/editsurvey/questions/questions.component';

export const appRoutes: Routes = [
  { path: 'auth/login', component: LoginComponent },
  { path: 'auth/register', component: RegisterComponent},
  { path: 'home', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
     // { path: 'trades', component: MytradesComponent },
    //  { path: 'editprofile', component: UserEditComponent },
      { path: 'admin/companylist', component: CompanyListComponent },
      { path: 'admin/editcompany/:companyid', component: EditCompanyComponent},
      { path: 'admin/rolemanager', component: RoleManagerComponent},
      { path: 'admin/usermanager', component: UserListComponent},
      { path: 'admin/usermanager/:companyid', component: UserListComponent},
      { path: 'admin/usermanager/edituser/:userid', component: EditUserComponent},
      { path: 'reports/:companyid', component: ReportsComponent},
      { path: 'bademails/:companyid', component: BadEmailsComponent},
      { path: 'survey/viewsurvey/:companyid/:surveyid', component: SurveyQuestionsComponent},
      { path: 'survey/adddata/:companyid/:surveyid', component: AddSurveyDataComponent},
      { path: 'admin/editsurvey/questions/:companyid/:surveyid', component: QuestionsComponent}
      // { path: '**', redirectTo: 'home', pathMatch: 'full'}  survey/adddata/
    ]
  },
  { path: '**', redirectTo: 'auth/login', pathMatch: 'full'}


];
