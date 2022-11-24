import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForumDashboardPageComponent } from './child-pages/forum-dashboard-page/forum-dashboard-page.component';
import { RouterModule } from '@angular/router';

import { MatCardModule } from "@angular/material/card";



@NgModule({
  declarations: [
    ForumDashboardPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{
      path: '',
      children: [
        {path: '', component: ForumDashboardPageComponent}
      ]
    }]),
    MatCardModule
  ]
})
export class ForumModule { }
