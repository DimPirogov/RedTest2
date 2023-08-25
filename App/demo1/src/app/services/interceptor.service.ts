import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class InterceptorAuthService implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler)
    :Observable<HttpEvent<any>> {
      const token = localStorage.getItem('jwt_token');
      if (token) {
        req = req.clone({
          setHeaders: { Authorization: `Bearer ${token}` }
          });
      }
      return next.handle(req);
  }

  constructor() { }
}
