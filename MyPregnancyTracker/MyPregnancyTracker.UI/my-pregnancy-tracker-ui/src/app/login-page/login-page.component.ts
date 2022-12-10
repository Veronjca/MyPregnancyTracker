import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { filter, first } from 'rxjs';
import { LoginRequest } from '../models/login-request.model';
import { AccountsService } from '../services/accounts.service';
import { UserService } from '../services/user.service';
import * as loginPageConstants from '../shared/constants/login-page.constants';

@Component({
  selector: 'app-login-page-component',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  loginPageConstants = loginPageConstants;
  spinnerFlag = false;
  
  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", 
    [
      Validators.required, 
      Validators.pattern('^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{8,}$')
    ])
  });

  loginRequest!: LoginRequest;

  constructor(private accountsService: AccountsService,
    private router: Router,
    private userService: UserService) { }

  ngOnInit(): void {
  }

  login(): void{
    this.loginRequest = {
      email: this.loginForm.value.email!,
      password: this.loginForm.value.password!
    }

    this.spinnerFlag = true;

    this.accountsService.loginUser(this.loginRequest)
    .pipe(filter(x => !!x), first())
    .subscribe(response => {
      sessionStorage.setItem("userId", response.id);
      sessionStorage.setItem("userName", response.userName)
      sessionStorage.setItem("email", response.email)
      sessionStorage.setItem("accessToken", response.accessToken)
      sessionStorage.setItem("refreshToken", response.refreshToken),
      sessionStorage.setItem("gestationalWeekAge", response.gestationalWeekAge.toString())

      this.router.navigate(['/user', response.id])

      let userId = sessionStorage.getItem('userId');
      this.userService.setGestationalWeek(userId!).pipe(first()).subscribe();

      this.spinnerFlag = false;
    });
  }
}
