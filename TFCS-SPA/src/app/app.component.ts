import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TFCS-SPA';
  currentRoute: string;
  showLeftNav: boolean;
  blankText = '';
  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService) { }

  ngOnInit() {
    this.router.events.subscribe(value => {
     // console.log('current route: ', this.router.url.toString());
      this.currentRoute = this.router.url.toString();

      if (this.currentRoute === '/auth/login' || this.currentRoute === '/auth/register') {
        this.showLeftNav = false;
      } else {
        this.showLeftNav = true;
      }
  });
  }
}
