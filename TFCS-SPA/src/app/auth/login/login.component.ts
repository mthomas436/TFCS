import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { User } from 'src/app/_models/user';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  user: Observable<User>;
  loginForm: FormGroup;
  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  loginUser() {
    if (this.loginForm.valid) {
      this.model.username = this.loginForm.get('username').value;
      this.model.password = this.loginForm.get('password').value;
      this.authService.login(this.model).subscribe(next => {
         this.toastr.success('Logged in successfully');
      }, error => {
        console.log(error);
         this.toastr.error(error);
      }, () => {
        this.router.navigate(['/home']);
      });
    } else {
       this.toastr.error('Invalid input');
    }

  }

}
