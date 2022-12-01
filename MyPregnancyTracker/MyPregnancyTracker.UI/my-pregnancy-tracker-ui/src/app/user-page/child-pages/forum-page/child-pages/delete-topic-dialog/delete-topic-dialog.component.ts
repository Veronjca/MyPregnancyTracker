import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { TopicsService } from 'src/app/services/topics.service';
import * as deleteTopicDialogconstants from '../../../../../shared/constants/delete-topic-dialog.constants';

@Component({
  selector: 'app-delete-topic-dialog',
  templateUrl: './delete-topic-dialog.component.html',
  styleUrls: ['./delete-topic-dialog.component.scss']
})
export class DeleteTopicDialogComponent implements OnInit {
  deleteTopicDialogconstants = deleteTopicDialogconstants;
  topicId!: number;
  category!: number;
  userId = sessionStorage.getItem('userId');

  constructor(private dialogRef: DialogRef<DeleteTopicDialogComponent>,
    @Inject(MAT_DIALOG_DATA) config: any,
    private topicsService: TopicsService,
    private router: Router) { 
      this.topicId = Number(config.topicId);
      this.category = Number(config.category);
    }

  ngOnInit(): void {
    
  }

  onDecline(){
    this.dialogRef.close();
  }

  onSubmit(){
    const category = this.category;
    
    this.topicsService.deleteTopic(this.topicId).pipe(first()).subscribe(response => {
      this.dialogRef.close();  
      this.router.navigate(['/user', this.userId, 'forum', 'topics'], {queryParams: {category: category}});
    });    
  }

}
