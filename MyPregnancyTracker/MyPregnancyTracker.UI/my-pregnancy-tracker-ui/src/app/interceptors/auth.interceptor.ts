import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { RefreshAccessTokenRequest } from '../models/refresh-access-token-request.models';
import { AccountsService } from '../services/accounts.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
  isRefreshing: boolean  = false;
  refreshAccessTokenRequest!: RefreshAccessTokenRequest;
  refreshToken = this.authService.getRefreshToken();
  userId = this.authService.getUserId();

  constructor(private authService: AuthService,
    private accountService: AccountsService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const accessToken = this.authService.getAccessToken();
    

    if(accessToken){
      req = req.clone({
        setHeaders: {Authorization: `Authorization token ${accessToken}`}
      });
    };

    return next.handle(req).pipe(
      catchError((error) => {
      if(error instanceof HttpErrorResponse && error.status === 401){
         return this.handle401Error(req, next);
      };

      return throwError(() => error);
    }));
  };
  
  private handle401Error(request: HttpRequest<any>, next: HttpHandler){
    if(!this.isRefreshing){
      this.isRefreshing = true;

      if(this.authService.isLoggedIn()){
        this.refreshAccessTokenRequest = {
          userId: this.userId,
          refreshToken: this.refreshToken
        };

        return this.authService.refreshAccessToken(this.refreshAccessTokenRequest).pipe(
          switchMap((response) => {
            sessionStorage.setItem('accessToken', response.accessToken);
            sessionStorage.setItem('refreshToken', response.refreshToken);

            this.isRefreshing = false;

            return next.handle(request);

          }),
          catchError((error) => {
              this.isRefreshing = false;

              if(error.status === 403){
                  this.accountService.logout();
                }               

                  return throwError(() => error);
                })
              )
           };
         };

          return next.handle(request);
        };

      }
