import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ResetPasswordRequest } from '../models/reset-password-request.model';
import { AccountsService } from '../services/accounts.service';
import * as resetPasswordConstants from '../shared/reset-password.constants';

@Component({
  selector: 'app-reset-password-page',
  templateUrl: './reset-password-page.component.html',
  styleUrls: ['./reset-password-page.component.scss']
})
export class ResetPasswordPageComponent implements OnInit {
  resetPasswordConstants = resetPasswordConstants;

  encodedEmail: string = '';
  encodedToken: string = '';

  private passwordMatchValidator: ValidatorFn = (formGroup: AbstractControl): ValidationErrors | null => {
    if (formGroup.get('newPassword')?.value === formGroup.get('confirmNewPassword')?.value)
      return null;
    else
      return {passwordMismatch: true};
  };
  resetPasswordForm = new FormGroup({
    newPassword: new FormControl("", 
    [
      Validators.required, 
      Validators.pattern('^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{8,}$')
    ]),
    confirmNewPassword: new FormControl("", Validators.required)
  }, {validators:  this.passwordMatchValidator});

  get confirmNewPassword() { return this.resetPasswordForm.get('confirmNewPassword'); }

  resetPasswordRequest!: ResetPasswordRequest;
  constructor(
    private accountSerivce: AccountsService,
    private route: ActivatedRoute
    ) { 
      this.route.queryParams.subscribe(params => {
        this.encodedEmail = params['email'];
        this.encodedToken = params['passwordToken']
      })
    }

  ngOnInit(): void {
  }

  resetPassword(){
    this.resetPasswordRequest = {
      encodedEmail: this.encodedEmail,
      encodedToken: this.encodedToken,
      newPassword: this.resetPasswordForm.value.newPassword!,
      confirmNewPassword: this.resetPasswordForm.value.confirmNewPassword!
    }

    this.accountSerivce.resetPassword(this.resetPasswordRequest).subscribe();
  }

  onConfirmPasswordInput(){
    if (this.resetPasswordForm.hasError('passwordMismatch')){
      this.confirmNewPassword?.setErrors([{'passwordMismatch': true}]);
      }
      else{
        this.confirmNewPassword?.setErrors(null);
      }
  }
}
