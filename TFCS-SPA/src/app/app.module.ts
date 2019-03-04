import { BrowserModule } from '@angular/platform-browser';
import { CardModule } from 'primeng/card';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { JwtModule, JWT_OPTIONS } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule } from 'primeng/button';
import { AppComponent } from './app.component';
import { PanelMenuModule } from 'primeng/panelmenu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AccordionModule } from 'primeng/accordion';
import { TabViewModule } from 'primeng/tabview';
import { ListboxModule } from 'primeng/listbox';
import { CheckboxModule } from 'primeng/checkbox';
import { InputSwitchModule } from 'primeng/inputswitch';
import { CalendarModule } from 'primeng/calendar';
import { RadioButtonModule } from 'primeng/radiobutton';
import {DialogModule} from 'primeng/dialog';


import { environment } from 'src/environments/environment';

import { AuthService } from './_services/auth.service';

import { appRoutes } from './routes';
import { TopNavComponent } from './nav/topnav/topnav.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home.component';
import { DefaultComponent } from './layouts/default/default.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { MenubarModule } from 'primeng/menubar';
import {InputTextModule} from 'primeng/inputtext';
import { LeftnavComponent } from './nav/leftnav/leftnav.component';
import { GeneralService } from './_services/general.service';
import { CompanyListComponent } from './admin/companylist/companylist.component';
import { ApplicationComponent } from './layouts/application/application.component';
import { MenuItemComponent } from './nav/menuitem/menuitem.component';
import {TreeModule} from 'primeng/tree';
import { EditCompanyComponent } from './admin/editcompany/editcompany.component';
// import { MessageService } from 'primeng/api';
import { ReportsComponent } from './reports/reports.component';
import { BadEmailsComponent } from './bademails/bademails.component';
import { UserListComponent } from './admin/usermanager/userlist/userlist.component';
import { RoleManagerComponent } from './admin/usermanager/rolemanager/rolemanager.component';
import { SurveyQuestionsComponent } from './survey/surveyquestions/surveyquestions.component';
import { DynamicFormComponent } from './formcomponents/dynamic-form/dynamic-form.component';
import { DynamicFormQuestionComponent } from './formcomponents/dynamic-form-question/dynamic-form-question.component';
import { QuestionService } from './_services/question.service';
import { QuestionControlService } from './_services/question-control.service';
import { EditUserComponent } from './admin/usermanager/edituser/edituser.component';
import { AddSurveyDataComponent } from './survey/addsurveydata/addsurveydata.component';


export function tokenGetter() {
  return localStorage.getItem('token');
}

export function jwtOptionsFactory() {
  return {
    tokenGetter: () => {
      return tokenGetter();
    },
    whitelistedDomains: environment.whitelist,
    blacklistedRoutes: environment.blacklist
  };
}


@NgModule({
   declarations: [
      AppComponent,
      CompanyListComponent,
      TopNavComponent,
      LoginComponent,
      RegisterComponent,
      HomeComponent,
      DefaultComponent,
      LeftnavComponent,
      ApplicationComponent,
      MenuItemComponent,
      EditCompanyComponent,
      ReportsComponent,
      BadEmailsComponent,
      UserListComponent,
      RoleManagerComponent,
      SurveyQuestionsComponent,
      DynamicFormComponent,
      DynamicFormQuestionComponent,
      EditUserComponent,
      AddSurveyDataComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot({
        positionClass: 'toast-bottom-right',
        preventDuplicates: true
     }),
    ButtonModule,
    CalendarModule,
    CardModule,
    CheckboxModule,
    MenubarModule,
    PanelMenuModule,
    InputTextModule,
    InputSwitchModule,
    FormsModule,
    ReactiveFormsModule,
    ListboxModule,
    AccordionModule,
    TabViewModule,
    TreeModule,
    DialogModule,
    RadioButtonModule,
    HttpClientModule,
     RouterModule.forRoot(appRoutes, {onSameUrlNavigation: 'reload'}),
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory: jwtOptionsFactory
      }
    })
  ],
  providers: [
    AuthService,
    GeneralService,
    ErrorInterceptorProvider,
    QuestionService,
    QuestionControlService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
