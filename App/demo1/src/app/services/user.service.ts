import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { User } from '../model/user';
import { JwtAuth } from '../model/jwtAuth';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  tokenURL = 'https://localhost:7053/api/User/Token';

  constructor(private http: HttpClient) { }

  public login(user: User): Observable<JwtAuth> {
    const requestOptions: Object = {
      responseType: 'text'
    }
    return this.http.post<JwtAuth>(this.tokenURL, user, requestOptions);
  }

}
