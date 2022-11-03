import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { AuthService } from './auth.service';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const accessToken = this.authService.getAccessToken();
    const refreshToken = this.authService.getRefreshToken();
    const userId = this.authService.getUserId();

    if(accessToken){
      req = req.clone({
        setHeaders: {Authorization: `Authorization token ${accessToken}`}
      })
    }

    return next.handle(req).pipe(
      catchError((error) => {
      if(error instanceof HttpErrorResponse){
          if(error.status === 401){
              
        }
      }

      return throwError(() => error);
    }))
  }
}
