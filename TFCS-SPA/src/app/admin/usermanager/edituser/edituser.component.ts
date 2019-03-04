import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/user';
import { Role } from 'src/app/_models/role';
import { AdminService } from 'src/app/_services/admin.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EditUserComponent implements OnInit {
  @Input() user: User;
  availableRoles: any[] = [];
  currentRoles: any[] = [];
  selectedRole: string;


  constructor(private adminService: AdminService, private toastr: ToastrService) { }

  ngOnInit() {
    this.selectedRole = '';

    this.adminService.getRoleList().subscribe((roles: Role[]) => {

      const arrayColumn: any[] = [];
      roles.forEach((value, index) => {
        this.availableRoles.push(value['name']);
      });

      this.currentRoles = this.user.roles.split(',');

      this.currentRoles.forEach((item) => {
        console.log(item);
        const itemindex: number = this.availableRoles.indexOf(item);
        console.log(itemindex);


        if (itemindex !== -1) {
          this.availableRoles.splice(itemindex, 1);
        }

    }, error => {
      this.toastr.error(error);
    });



    });

  }

  addRole() {
    if(this.selectedRole != '') {
      this.currentRoles.indexOf(this.selectedRole) === -1 ?   
        this.currentRoles.push(this.selectedRole) : console.log('This role already exists');
    }
  }

}
