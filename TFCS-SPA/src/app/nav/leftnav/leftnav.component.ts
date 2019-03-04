import { Component, OnInit } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { GeneralService } from 'src/app/_services/general.service';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/_services/admin.service';
import { Company } from 'src/app/_models/company';
import { Router } from '@angular/router';

@Component({
  selector: 'app-leftnav',
  templateUrl: './leftnav.component.html',
  styleUrls: ['./leftnav.component.css']
})
export class LeftnavComponent implements OnInit {
  companies: Company[];
  items: MenuItem[] = [];
  constructor( private generalService: GeneralService,
               private toastr: ToastrService,
               private adminService: AdminService,
               private router: Router) { }

  ngOnInit() {
    this.getCompanies();
  }

  getCompanies() {
    this.adminService.getCompanies().subscribe((companies: Company[]) => {
      this.companies = companies;
      this.generateMenuItems();
    }, error => {
      this.toastr.error(error);
    });
  }

  menuItemClick(id, linktype) {
    if( linktype == 'reports' ) {
      this.router.navigate(['reports/' + id]);
    }
    if( linktype == 'emails' ) {
      this.router.navigate(['bademails/' + id]);
    }
  }

  goToAddSurvey(companyId: number, surveyId: number) {
    this.router.navigate(['survey/viewsurvey/', companyId, surveyId]);
  }

  addSurveyData(companyId: number, surveyId: number) {
    this.router.navigate(['survey/adddata/', companyId, surveyId]);
  }

  manageUsers(companyId: number) {
    this.router.navigate(['admin/usermanager/', companyId]);
  }

  generateMenuItems() {
    this.companies.forEach((item, index) => {
      const mnuItem: MenuItem = {};
      mnuItem.label = item.name;
      mnuItem.icon = 'pi pi-pw pi-file';

     // console.log(item.surveys);

      mnuItem.items = [];

      const subItems: MenuItem[] = [];
      item.surveys.forEach((sitem) => {
        const surveyItem: MenuItem = {
          label: sitem.surveyTypes.description,
          icon: 'pi pi-fw pi-plus',
          items: [
            { label: ' View Reports', icon: 'fa fa-book', command: (event) => { this.menuItemClick(sitem.companyId, 'reports'); }},
            { label: ' View Bad Emails', icon: 'fa fa-envelope', command: (event) => { this.menuItemClick(sitem.companyId, 'emails'); }},
            { label: ' View Survey Page', icon: 'fa fa-desktop', command: (event) => { this.goToAddSurvey(sitem.companyId, sitem.surveyId);}},
            { label: ' Add Survey Data', icon: 'fa fa-list-alt', command: (event) => { this.addSurveyData(sitem.companyId, sitem.surveyId); }},
            { label: ' Manage Users', icon: 'fa fa-user-circle', command: (event) => { this.manageUsers(sitem.companyId); }}
          ]
        };

        subItems.push(surveyItem);

      });
     // console.log(subItems);
      mnuItem.items = subItems;
/*
      mnuItem.items = [{
                          label: 'New',
                          icon: 'pi pi-fw pi-plus',
                          items: [


                              //{label: 'User', icon: 'pi pi-fw pi-user-plus'},
                              //{label: 'Filter', icon: 'pi pi-fw pi-filter'}
                          ]
                      }

                      // ,
                      // {label: 'Open', icon: 'pi pi-fw pi-external-link'},
                      // {separator: true},
                      // {label: 'Quit', icon: 'pi pi-fw pi-times'}
                    ];

*/
        this.items.push(mnuItem);
    });

  }
}
