import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/_services/admin.service';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Role } from 'src/app/_models/role';
import { RoleToCreate } from 'src/app/_models/roletocreate';

@Component({
  selector: 'app-rolemanager',
  templateUrl: './rolemanager.component.html',
  styleUrls: ['./rolemanager.component.css']
})
export class RoleManagerComponent implements OnInit {
  newRoleName: RoleToCreate;
  hideForm: boolean ;
  roleList: Role[];
  constructor(private adminService: AdminService, private authService: AuthService, 
              private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.hideForm = true;
    this.newRoleName = {rolename : ''};

    this.getRoleList();
  }

  displayRoleForm() {
    this.hideForm = false;
  }



  addRole() {
    this.adminService.createRole(this.newRoleName).subscribe((roles: Role[]) => {
       this.toastr.success('Role created successfully');
       this.hideForm = true;
       this.roleList = roles;
    }, error => {
       this.toastr.error(error);
    });
  }

  getRoleList() {
    this.adminService.getRoleList().subscribe((roles: Role[]) => {
      this.roleList = roles;
    }, error => {
      this.toastr.error(error);
    });
  }
}
