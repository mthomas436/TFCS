import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/_services/admin.service';
import { User } from 'src/app/_models/user';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];
  selectedUser: User;
  display: boolean = false;
  companyId: number;
  constructor(private adminService: AdminService,  private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getUserList();
    this.companyId = 0;



    this.route.params.subscribe(params => {
      this.companyId = +params['companyid'];
      console.log(this.companyId);
    });
  }

  getUserList() {
    this.adminService.getAllUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.toastr.error(error);
    });
  }

  getCompanyUserList() {
    this.adminService.getCompanyUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.toastr.error(error);
    });
  }

  editUser(user: User) {
    this.display = true;
    this.selectedUser = user;
  }

}
