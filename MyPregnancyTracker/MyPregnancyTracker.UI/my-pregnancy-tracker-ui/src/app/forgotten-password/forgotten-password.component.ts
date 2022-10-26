import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SendResetPasswordEmailRequest } from '../models/send-reset-password-email.model';
import { AccountsService } from '../services/accounts.service';
import * as forgottenPasswordConstants from '../shared/forgotten-password.constants';

@Component({
  selector: 'app-forgotten-password',
  templateUrl: './forgotten-password.component.html',
  styleUrls: ['./forgotten-password.component.scss']
})
export class ForgottenPasswordComponent implements OnInit {

  forgottenPasswordConstants = forgottenPasswordConstants;

  forgottenPasswordForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email])
  });

  sendResetPasswordEmailRequest!: SendResetPasswordEmailRequest;
  constructor(private accountService: AccountsService) { }

  ngOnInit(): void {
  }

  sendResetPasswordEmail(){
    this.sendResetPasswordEmailRequest = {
    email: this.forgottenPasswordForm.value.email!
    }

    this.accountService.sendResetPasswordEmail(this.sendResetPasswordEmailRequest).subscribe();
  }
}
