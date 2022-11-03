import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmEmailPageComponent } from './confirm-email-page/confirm-email-page.component';
import { ForgottenPasswordComponent } from './forgotten-password-page/forgotten-password.component';
import { UserPageComponent } from './user-page/user-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { PostRegisterPageComponent } from './post-register-page/post-register-page.component';
import { PostResetPasswordPageComponent } from './post-reset-password-page/post-reset-password-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { ResetPasswordPageComponent } from './reset-password-page/reset-password-page.component';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  {path:"", component: HomePageComponent},
  {path:"login", component: LoginPageComponent},
  {path:"register", component: RegisterPageComponent},
  {path:"confirm-email", component: ConfirmEmailPageComponent},
  {path:"post-register", component: PostRegisterPageComponent},
  {path:"forgotten-password", component: ForgottenPasswordComponent},
  {path: "reset-password", component: ResetPasswordPageComponent},
  {path: "post-reset-password", component: PostResetPasswordPageComponent},
  {path: "user/:id", component: UserPageComponent, canActivate: [AuthGuardService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
