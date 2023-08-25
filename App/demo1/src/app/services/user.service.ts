import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

import { User } from '../model/user';
import { JwtAuth } from '../model/jwtAuth';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  tokenURL = 'https://localhost:7053/api/User/Token';
  public loggedIn = new BehaviorSubject<boolean>(false);
  public loggedOut = new BehaviorSubject<boolean>(true);

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  get isLoggedOut() {
    return this.loggedOut.asObservable();
  }

  constructor(private http: HttpClient, private router: Router) { }

  // public login(user: User): Observable<JwtAuth> {
  //   const requestOptions: Object = {
  //     responseType: 'text'
  //   }
  //   return this.http.post<JwtAuth>(this.tokenURL, user, requestOptions);
  // }
  public login(user: User): Observable<any> {
    const requestOptions: Object = {
      responseType: 'text'
    }
    return this.http.post<JwtAuth>(this.tokenURL, user, requestOptions);
  }

  public logout() {
    localStorage.removeItem('jwt_token');
    this.loggedIn.next(false);
    this.loggedOut.next(true);
    this.router.navigate(['/']);
  }
}
