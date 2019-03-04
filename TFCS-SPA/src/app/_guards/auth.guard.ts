import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) {}
    canActivate(): boolean {
      if (this.authService.loggedIn()) {
        return true;
      }

      this.router.navigate(['/auth/login']);
      return false;
    }
  }