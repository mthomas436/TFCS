import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  currentUser: User;
  userfullname = new BehaviorSubject<string>('user');
  currentUserFullName = this.userfullname.asObservable();
constructor(private http: HttpClient) { }

register(user: User) {
  return this.http.post(this.baseUrl + 'register', user);
}


login(model: any) {
  return this.http.post(this.baseUrl + 'login', model)
    .pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          const curUserInfo: User = Object.assign({}, user.user);
          localStorage.setItem('token', user.token);
          this.updateLocalStorageInfo(curUserInfo);
          this.changeUserInfo();
        }
      })
    );
 }

private changeUserInfo() {
  const user: User = this.getUserInfoFromLocalStorage();
  this.userfullname.next(user.firstname + ' ' + user.lastname);
}

updateLocalStorageInfo(userToUpdate: User) {
  if ( localStorage.getItem('user') )  {
     localStorage.removeItem('user');
  }
  localStorage.setItem('user', JSON.stringify(userToUpdate));
}

getUserInfoFromLocalStorage(): User {
  return Object.assign({}, JSON.parse( localStorage.getItem('user') ) );
}

getUserFullName() {
  this.changeUserInfo();
  return this.currentUserFullName;
}


loggedIn() {
  return !this.jwtHelper.isTokenExpired( localStorage.getItem('token') );
}

getDecodedToken() {
 return this.jwtHelper.decodeToken( localStorage.getItem('token') );
}

getUserid() {
 return +this.getDecodedToken().nameid;
}


}

