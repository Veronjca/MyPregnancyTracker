import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatTooltipModule} from '@angular/material/tooltip';

import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { ConfirmEmailPageComponent } from './confirm-email-page/confirm-email-page.component';
import { PostRegisterPageComponent } from './post-register-page/post-register-page.component';
import { ForgottenPasswordComponent } from './forgotten-password-page/forgotten-password.component';
import { ResetPasswordPageComponent } from './reset-password-page/reset-password-page.component';
import { PostResetPasswordPageComponent } from './post-reset-password-page/post-reset-password-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { SidenavComponent } from './sidenav/sidenav.component';
import { GestationalWeekCardComponent } from './gestational-week-card/gestational-week-card.component';


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
    PostResetPasswordPageComponent,
    UserPageComponent,
    SidenavComponent,
    GestationalWeekCardComponent
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
    HttpClientModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatTooltipModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
