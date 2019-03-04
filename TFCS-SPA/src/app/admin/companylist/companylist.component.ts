import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/_models/company';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-companylist',
  templateUrl: './companylist.component.html',
  styleUrls: ['./companylist.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: Company[];
  constructor(private adminService: AdminService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getCompanies();
  }

  getCompanies() {
    this.adminService.getCompanies().subscribe((companies: Company[]) => {
      this.companies = companies;
    }, error => {
      this.toastr.error(error);
    });
  }

}
