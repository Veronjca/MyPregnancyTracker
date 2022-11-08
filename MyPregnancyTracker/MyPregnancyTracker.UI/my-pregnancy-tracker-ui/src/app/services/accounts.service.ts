import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfirmEmailRequest } from '../models/confirm-email.model';
import * as routes from '../shared/constants/routes.constants';
import { RegisterRequest } from '../models/register-request.model';
import { LoginRequest } from '../models/login-request.model';
import { ResendConfirmationEmailRequest } from '../models/resend-confirmation-email.model';
import { SendResetPasswordEmailRequest } from '../models/send-reset-password-email.model';
import { ResetPasswordRequest } from '../models/reset-password-request.model';
import { LoginResponse } from '../models/login-response.model';
import { RegisterResponse } from '../models/register-response.model';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private httpClient: HttpClient) { }

  confirmEmail(model: ConfirmEmailRequest): Observable<any>{
    return this.httpClient.post<any>(routes.CONFIRM_EMAIL_ENDPOINT, model);
  }

  registerUser(model: RegisterRequest): Observable<RegisterResponse>{
    return this.httpClient.post<RegisterResponse>(routes.REGISTER_ENDPOINT, model);
  }

  loginUser(model: LoginRequest): Observable<LoginResponse>{
    return this.httpClient.post<LoginResponse>(routes.LOGIN_ENDPOINT, model);
  }

  resendConfirmationEmail(model: ResendConfirmationEmailRequest): Observable<any>{
    return this.httpClient.post<any>(routes.RESEND_CONFIRMATION_EMAIL_ENDPOINT, model);
  }

  sendResetPasswordEmail(model: SendResetPasswordEmailRequest): Observable<any>{
    return this.httpClient.post<any>(routes.SEND_RESET_PASSWORD_EMAIL_ENDPOINT, model);
  }

  resetPassword(model: ResetPasswordRequest): Observable<any>{
    return this.httpClient.post<any>(routes.RESET_PASSWORD_ENDPOINT, model);
  }

  logout(): void{
    sessionStorage.clear();
  }
}
