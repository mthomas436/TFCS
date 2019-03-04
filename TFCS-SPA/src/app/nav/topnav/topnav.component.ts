import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-topnav',
  templateUrl: './topnav.component.html',
  styleUrls: ['./topnav.component.css']
})
export class TopNavComponent implements OnInit {
  user: User;
  userfullname: string;
  userId: number;
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
    if (this.authService.loggedIn()) {
      this.userId = this.authService.getUserid();
      this.authService.getUserFullName().subscribe(userfullname => this.userfullname = userfullname);
      // this.userfullname = this.authService.getUserFullName();
    }
  }



  loggedIn() {
    return this.authService.loggedIn();
  }

  logOut() {
    this.user = null;
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    // this.toastr.success('Logged out');
    this.router.navigate(['auth/login']);
  }

}
