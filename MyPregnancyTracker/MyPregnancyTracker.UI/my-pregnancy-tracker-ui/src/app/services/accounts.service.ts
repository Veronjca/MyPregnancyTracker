import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfirmEmailRequest } from '../models/confirm-email.model';
import * as routs from '../shared/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  constructor(private httpClient: HttpClient) { }

  confirmEmail(model: ConfirmEmailRequest): Observable<any>{
    return this.httpClient.post<any>(routs.CONFIRM_EMAIL_ENDPOINT, model);
  }
}
