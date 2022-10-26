import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginRequest } from '../models/login-request.model';
import { AccountsService } from '../services/accounts.service';
import * as loginPageConstants from '../shared/constants/login-page.constants';

@Component({
  selector: 'app-login-page-component',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  loginPageConstants = loginPageConstants;
  
  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", 
    [
      Validators.required, 
      Validators.pattern('^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{8,}$')
    ])
  });

  loginRequest!: LoginRequest;

  constructor(private accountsService: AccountsService) { }

  ngOnInit(): void {
  }

  login(): void{
    this.loginRequest = {
      email: this.loginForm.value.email!,
      password: this.loginForm.value.password!
    }

    this.accountsService.loginUser(this.loginRequest).subscribe();
  }
}
