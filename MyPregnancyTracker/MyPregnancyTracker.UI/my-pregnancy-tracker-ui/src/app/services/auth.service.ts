import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient} from '@angular/common/http';
import * as routes from '../shared/constants/routes.constants';
import { RefreshAccessTokenResponse } from '../models/refresh-access-token-response.model';
import { RefreshAccessTokenRequest } from '../models/refresh-access-token-request.models';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient,
    private router: Router) { }

  public getAccessToken(): string {
    return localStorage.getItem('accessToken')!;
  }

  public getRefreshToken(): string{
    return localStorage.getItem("refreshToken")!;
  }

  public getUserId(): string{
    return this.router.url.replace('/user/', '');
  }

  public refreshAccessToken(model: RefreshAccessTokenRequest): Observable<RefreshAccessTokenResponse>{
    return this.httpClient.post<RefreshAccessTokenResponse>(routes.REFRESH_ACCESS_TOKEN_ENDPOINT, model);
  }

  public isLoggedIn(): boolean{
    if(localStorage.getItem("email")){
        return true;
    };  
    
    return false
  }
}
