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
import { AuthGuard} from './guards/auth.guard';
import { IsSignedInGuard } from './guards/is-signed-in.guard';

const routes: Routes = [
  {path:"", component: HomePageComponent, canActivate: [IsSignedInGuard]},
  {path:"login", component: LoginPageComponent, canActivate: [IsSignedInGuard]},
  {path:"register", component: RegisterPageComponent, canActivate: [IsSignedInGuard]},
  {path:"confirm-email", component: ConfirmEmailPageComponent, canActivate: [IsSignedInGuard]},
  {path:"post-register", component: PostRegisterPageComponent, canActivate: [IsSignedInGuard]},
  {path:"forgotten-password", component: ForgottenPasswordComponent, canActivate: [IsSignedInGuard]},
  {path: "reset-password", component: ResetPasswordPageComponent, canActivate: [IsSignedInGuard]},
  {path: "post-reset-password", component: PostResetPasswordPageComponent, canActivate: [IsSignedInGuard]},
  {
    path: "user/:id", 
    component: UserPageComponent,
     loadChildren: () => import("../app/user-page/user.module").then(module => module.UserModule), 
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
