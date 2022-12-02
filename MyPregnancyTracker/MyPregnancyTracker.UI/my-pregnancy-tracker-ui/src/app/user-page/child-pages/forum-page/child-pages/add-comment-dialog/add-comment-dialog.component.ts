import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AddCommentRequest } from 'src/app/models/add-comment-request.model';
import { CommentsService } from 'src/app/services/comments.service';
import * as addCommentDialogConstants from '../../../../../shared/constants/add-comment-dialog.constants';

@Component({
  selector: 'app-add-comment-dialog',
  templateUrl: './add-comment-dialog.component.html',
  styleUrls: ['./add-comment-dialog.component.scss']
})
export class AddCommentDialogComponent implements OnInit {
  addCommentDialogConstants = addCommentDialogConstants;
  topicId!: number;
  userId!: string;
  addCommentRequestModel!: AddCommentRequest;
  addCommentFormControl = new FormControl('', [Validators.required, Validators.maxLength(2000)]);

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  private dialogRef: MatDialogRef<AddCommentDialogComponent>,
  private commentsService: CommentsService,
  private router: Router) {
    this.topicId = data.topicId;
    this.userId = data.userId;
   }

  ngOnInit(): void {
  }

  addComment(){
    this.addCommentRequestModel = {
      topicId: this.topicId,
      userId: this.userId,
      content: this.addCommentFormControl.value!
    }

    this.commentsService.addComment(this.addCommentRequestModel).subscribe(response => {
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/user', this.userId, 'forum', 'topics', this.topicId]);
        });
    });

    this.dialogRef.close();
  }

}
