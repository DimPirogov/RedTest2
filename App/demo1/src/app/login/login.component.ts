import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Location } from '@angular/common';

import { User } from '../model/user';
import { UserService } from '../services/user.service';
import { JwtAuth } from '../model/jwtAuth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginDto = new User();
  jwtDto = new JwtAuth();

  constructor(private userService: UserService, private location: Location) { }

  login(loginDto: User) {
    this.userService.login(loginDto).subscribe((jwtDto) => {
      //this.jwtDto = jwtDto;
      localStorage.setItem('jwtToken', jwtDto.token);
      this.goBack();
    });
  }

  goBack(): void {
    this.location.back();
  }
}
