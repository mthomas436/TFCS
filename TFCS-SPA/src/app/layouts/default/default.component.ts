import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.css']
})
export class DefaultComponent implements OnInit {
  currentRoute: string;
  showLeftNav: boolean;
  loggedIn: boolean;
  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService) { }

  ngOnInit() {
    this.loggedIn = this.authService.loggedIn();
    this.router.events.subscribe(value => {
      //console.log('current route: ', this.router.url.toString());
      this.currentRoute = this.router.url.toString();

      if(this.currentRoute === '/auth/login' || this.currentRoute === '/auth/register') {
        this.showLeftNav = false;
      } else {
        this.showLeftNav = true;
      }
  });
  }

}
