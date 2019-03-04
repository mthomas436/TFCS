import { Component, OnInit } from '@angular/core';
import { Survey } from 'src/app/_models/survey';
import { AdminService } from 'src/app/_services/admin.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { Company } from 'src/app/_models/company';
import { SurveyType } from 'src/app/_models/surveytype';
import { SurveyToAdd } from 'src/app/_models/surveytoadd';


@Component({
  selector: 'app-editcompany',
  templateUrl: './editcompany.component.html',
  styleUrls: ['./editcompany.component.css']
})
export class EditCompanyComponent implements OnInit {
  companyId: number;
  company: Company;
  companyName: string;
  surveyTypes: SurveyType[];
  selectedSurveyType: number;
  selectedSurveyTypes: number[];
  dataReady = false;
  active: boolean;
  surveyList: Survey[];
  surveyToAdd: SurveyToAdd;

  constructor(private adminService: AdminService, private toastr: ToastrService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.selectedSurveyTypes = [];
    this.surveyList = [];
    this.route.params.subscribe(params => {
      this.companyId = +params['companyid'];
      this.getCompanyDetail();
    });

    this.getSurveyTypes();
  }

  getSurveyTypes() {
    this.adminService.getSurveyTypes().subscribe((surveyTypes: SurveyType[]) => {
      this.surveyTypes = surveyTypes;
    }, error => {
      this.toastr.error(error);
    });
  }


  getCompanyDetail() {
    this.adminService.getCompanyDetail(this.companyId).subscribe((company: Company) => {
      this.company = company;
      this.active = this.company.active;
      this.dataReady = true;

      const currentSurveys: number[] = [];

      this.company.surveys.forEach((item, index) => {
        currentSurveys.push(item.surveyTypeId);
      });
      this.selectedSurveyTypes = currentSurveys;

      this.surveyList = company.surveys;

    }, error => {
      this.toastr.error(error);
    });
  }

  updateActive(event) {
    const isChecked = event.checked;

    if (isChecked) {
      this.company.active = true;
    } else {
      this.company.active = false;
    }

  }

  updateCompany() {
    this.company.active = this.active;
    this.company.name = this.companyName;

    this.adminService.updateCompany(this.company).subscribe((company: Company) => {
         this.company = company;
    });
  }


  updateCompanySurveys() {
    // Add all checked items into the survey array.

    console.log(this.company);

    // Figure out which ones are new
    const currentItems: number[] = [];
    const newitems: number[] = [];
    let itemstoremove: number[] = [];


    // store current items
    this.company.surveys.forEach((item, index) => {
       currentItems.push(item.surveyTypeId);
    });

    console.log('current items' + currentItems);

    // new items
      this.selectedSurveyTypes.filter(e => !currentItems.includes(e)).forEach((item, index) => {
        newitems.push(item);
      });

      console.log('new items' + newitems);

    // Items to remove
     currentItems.filter(e => !this.selectedSurveyTypes.includes(e)).forEach((item, index) => {
      itemstoremove.push(item);
    });

    console.log('selected' + this.selectedSurveyTypes);
    console.log('remove' + itemstoremove);


    if (newitems.length > 0) {
      newitems.forEach((item, index) => {
        const surveyToAdd = <Survey>{};
        surveyToAdd.companyId = this.companyId;
        surveyToAdd.active = true;
        surveyToAdd.surveyTypeId = item;

        this.adminService.addSurveyToCompany(surveyToAdd).subscribe((company: Company) => {
          this.company = company;
        });
      });
     }

    if (itemstoremove.length > 0) {
      itemstoremove.forEach((item, index) => {
        const surveyToRemove = <Survey>{};
        surveyToRemove.companyId = this.companyId;
        surveyToRemove.active = false;
        surveyToRemove.surveyTypeId = item;

        this.adminService.removeSurveyFromCompany(surveyToRemove).subscribe((company: Company) => {
          this.company = company;
        });
      });
    }



  }



  editSurvey(survey: Survey) {
      this.router.navigate(['admin/editsurvey/questions/' + survey.companyId + '/' + survey.surveyId]);
  }
}
