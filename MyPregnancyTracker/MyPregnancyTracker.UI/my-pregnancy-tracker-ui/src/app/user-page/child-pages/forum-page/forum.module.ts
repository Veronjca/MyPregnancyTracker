import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from "@angular/forms";

import { MatCardModule } from "@angular/material/card";
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';


import { TopicsPageComponent } from './child-pages/topics-page/topics-page.component';
import { AddTopicPageComponent } from './child-pages/add-topic-page/add-topic-page.component';
import { TopicPageComponent } from './child-pages/topic-page/topic-page.component';
import { DeleteTopicDialogComponent } from './child-pages/delete-topic-dialog/delete-topic-dialog.component';
import { EditTopicBottomSheetComponent } from './child-pages/edit-topic-bottom-sheet/edit-topic-bottom-sheet.component';



@NgModule({
  declarations: [
    TopicsPageComponent,
    AddTopicPageComponent,
    TopicPageComponent,
    DeleteTopicDialogComponent,
    EditTopicBottomSheetComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{
      path: '',
      children: [
        {path: 'topics', component: TopicsPageComponent},
        {path: 'topics/:topicId', component: TopicPageComponent}
      ]
    }]),
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    MatButtonToggleModule,
    MatTooltipModule,
    MatBottomSheetModule
  ]
})
export class ForumModule { }
