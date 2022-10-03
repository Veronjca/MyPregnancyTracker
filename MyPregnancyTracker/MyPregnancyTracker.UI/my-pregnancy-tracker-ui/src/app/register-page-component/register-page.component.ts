import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registerForm = new FormGroup({
      firstName: new FormControl("", Validators.required),
      lastName: new FormControl("", Validators.required),
      userName: new FormControl("", Validators.required),
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", 
      [
        Validators.required, 
        Validators.pattern('^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{8,}$')
      ]),
      confirmPassword: new FormControl("", Validators.required),
      firstDayOfLastMenstruation: new FormControl("", Validators.required),
      acceptTACCheckbox: new FormControl(false, Validators.requiredTrue)

  });
  constructor() { }

  ngOnInit(): void {
  }

  register(): void{

  }
}
