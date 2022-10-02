import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page-component/home-page/home-page.component';
import { LoginPageComponent } from './login-page-component/login-page-component.component';

const routes: Routes = [
  {path:"", component: HomePageComponent},
  {path:"login", component: LoginPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
