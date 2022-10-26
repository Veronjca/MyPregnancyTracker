import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page-component/home-page/home-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import { LoginPageComponent } from './login-page-component/login-page.component';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterPageComponent } from './register-page-component/register-page.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { ConfirmEmailPageComponent } from './confirm-email-page/confirm-email-page.component';
import { HttpClientModule } from '@angular/common/http';
import { PostRegisterPageComponent } from './post-register-page/post-register-page.component';
import { ForgottenPasswordComponent } from './forgotten-password/forgotten-password.component';
import { ResetPasswordPageComponent } from './reset-password-page/reset-password-page.component';
import { PostResetPasswordPageComponent } from './post-reset-password-page/post-reset-password-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    RegisterPageComponent,
    ConfirmEmailPageComponent,
    PostRegisterPageComponent,
    ForgottenPasswordComponent,
    ResetPasswordPageComponent,
    PostResetPasswordPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
