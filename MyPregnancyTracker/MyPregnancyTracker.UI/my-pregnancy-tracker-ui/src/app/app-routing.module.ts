import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmEmailPageComponent } from './confirm-email-page/confirm-email-page.component';
import { ForgottenPasswordComponent } from './forgotten-password/forgotten-password.component';
import { HomePageComponent } from './home-page-component/home-page/home-page.component';
import { LoginPageComponent } from './login-page-component/login-page.component';
import { PostRegisterPageComponent } from './post-register-page/post-register-page.component';
import { PostResetPasswordPageComponent } from './post-reset-password-page/post-reset-password-page.component';
import { RegisterPageComponent } from './register-page-component/register-page.component';
import { ResetPasswordPageComponent } from './reset-password-page/reset-password-page.component';

const routes: Routes = [
  {path:"", component: HomePageComponent},
  {path:"login", component: LoginPageComponent},
  {path:"register", component: RegisterPageComponent},
  {path:"confirm-email", component: ConfirmEmailPageComponent},
  {path:"post-register", component: PostRegisterPageComponent},
  {path:"forgotten-password", component: ForgottenPasswordComponent},
  {path: "reset-password", component: ResetPasswordPageComponent},
  {path: "post-reset-password", component: PostResetPasswordPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
