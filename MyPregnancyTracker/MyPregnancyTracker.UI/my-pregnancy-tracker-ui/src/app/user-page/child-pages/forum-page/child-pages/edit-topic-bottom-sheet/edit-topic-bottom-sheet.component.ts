import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { TopicModel } from 'src/app/models/topic.model';
import { TopicsService } from 'src/app/services/topics.service';
import * as constants from '../../../../../shared/constants/edit-topic-bottom-sheet.constants';

@Component({
  selector: 'app-edit-topic-bottom-sheet',
  templateUrl: './edit-topic-bottom-sheet.component.html',
  styleUrls: ['./edit-topic-bottom-sheet.component.scss']
})
export class EditTopicBottomSheetComponent implements OnInit {
  topicModel!: TopicModel;
  userId = sessionStorage.getItem('userId');
  constants = constants;
  editTopicForm: FormControl = new FormControl('');

  constructor(@Inject (MAT_BOTTOM_SHEET_DATA) public data: {topic: TopicModel},
  private topicsService: TopicsService,
  private bottomSheetRef: MatBottomSheetRef) { 
    this.topicModel = data.topic;
    this.editTopicForm.setValue(this.topicModel.content);
  }

  ngOnInit(): void {
  }

  editTopic(){
    this.topicModel.content = this.editTopicForm.value;
    this.topicsService.editTopic(this.topicModel, this.userId!).subscribe();
    this.bottomSheetRef.dismiss();
  }
}
