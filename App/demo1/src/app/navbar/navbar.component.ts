import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { UserService } from '../services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn$: Observable<boolean> | undefined;
  isLoggedOut$: Observable<boolean> | undefined;
  
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.isLoggedIn$ = this.userService.isLoggedIn;
    this.isLoggedOut$ = this.userService.isLoggedOut;
    //this.isLoggedIn$.subscribe((val) => {console.log(val)} );
  }

  onLogout() {
    this.userService.logout();
  }
}
