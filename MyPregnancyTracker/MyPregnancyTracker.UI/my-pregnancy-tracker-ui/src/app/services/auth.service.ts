import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient} from '@angular/common/http';
import * as routes from '../shared/constants/routes.constants';
import { RefreshAccessTokenResponse } from '../models/refresh-access-token-response.model';
import { RefreshAccessTokenRequest } from '../models/refresh-access-token-request.models';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  jwtHelper: JwtHelperService = new JwtHelperService();

  get isAdmin(): Observable<boolean>{
    return of(this.isUserAdmin());
  }

  constructor(private httpClient: HttpClient,
    private router: Router) { }

  public getAccessToken(): string {
    return sessionStorage.getItem('accessToken')!;
  }

  public getRefreshToken(): string{
    return sessionStorage.getItem("refreshToken")!;
  }

  public getUserId(): string{
    return sessionStorage.getItem('userId')!;
  }

  public refreshAccessToken(model: RefreshAccessTokenRequest): Observable<RefreshAccessTokenResponse>{
    return this.httpClient.post<RefreshAccessTokenResponse>(routes.REFRESH_ACCESS_TOKEN_ENDPOINT, model);
  }

  public isLoggedIn(): boolean{
    if(sessionStorage.getItem("email")){
        return true;
    };  
    
    return false
  }

  private isUserAdmin(): boolean{
    const token = this.getAccessToken();
    let decodedToken = this.jwtHelper.decodeToken(token);

    return decodedToken.role.includes('admin');
  }
}
