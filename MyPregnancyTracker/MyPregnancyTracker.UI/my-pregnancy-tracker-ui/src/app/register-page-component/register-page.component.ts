import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { __values } from 'tslib';
import { RegisterRequest } from '../models/register-request.model';
import { AccountsService } from '../services/accounts.service';
import * as registerPageConstants from '../shared/register-page.constants';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registerPageConstants = registerPageConstants;

  private passwordMatchValidator: ValidatorFn = (formGroup: AbstractControl): ValidationErrors | null => {
    if (formGroup.get('password')?.value === formGroup.get('confirmPassword')?.value)
      return null;
    else
      return {passwordMismatch: true};
  };
  
  registerForm = new FormGroup({
      firstName: new FormControl("", Validators.required),
      lastName: new FormControl("", Validators.required),
      userName: new FormControl("", Validators.required),
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", 
      [
        Validators.required, 
        Validators.pattern('^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{8,}$'),
       
      ]),
      confirmPassword: new FormControl("", Validators.required),
      firstDayOfLastMenstruation: new FormControl("", Validators.required),
      acceptTACCheckbox: new FormControl(false, Validators.requiredTrue)
  }, {validators:  this.passwordMatchValidator});

  formRequest!: RegisterRequest;

  constructor(
    private accountsService: AccountsService,
    private router: Router) 
    { }

  get password() { return this.registerForm.get('password'); }
  get confirmPassword() { return this.registerForm.get('confirmPassword'); }

  ngOnInit(): void {
  }

  register(): void{
    this.formRequest = {
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      userName: this.registerForm.value.userName!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
      confirmPassword: this.registerForm.value.confirmPassword!,
      firstDayOfLastMenstruation: this.registerForm.value.firstDayOfLastMenstruation!
    }
     
    this.accountsService.registerUser(this.formRequest).subscribe(response => {
      this.router.navigate(['/post-register'], {queryParams: {email: response.encodedEmail}});
    });
  }

  onPasswordInput(){
    if (this.registerForm.hasError('passwordMismatch')){
    this.confirmPassword?.setErrors([{'passwordMismatch': true}]);
    }
    else{
      this.confirmPassword?.setErrors(null);
    }
  }
}


