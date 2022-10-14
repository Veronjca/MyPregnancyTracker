import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmEmailPageComponent } from './confirm-email-page/confirm-email-page.component';
import { HomePageComponent } from './home-page-component/home-page/home-page.component';
import { LoginPageComponent } from './login-page-component/login-page.component';
import { RegisterPageComponent } from './register-page-component/register-page.component';

const routes: Routes = [
  {path:"", component: HomePageComponent},
  {path:"login", component: LoginPageComponent},
  {path:"register", component: RegisterPageComponent},
  {path:"confirm-email", component: ConfirmEmailPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
