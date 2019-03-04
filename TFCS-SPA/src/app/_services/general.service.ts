import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Menu } from '../_models/menu';


@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseUrl = environment.apiUrl + 'general/';
  jwtHelper = new JwtHelperService();
  userId = this.authService.getUserid();

  constructor(private http: HttpClient, private authService: AuthService) { }

  getMenuItems(): Observable<Menu> {
    return this.http.get<Menu>(this.baseUrl + 'getMenuItems');
  }

}
