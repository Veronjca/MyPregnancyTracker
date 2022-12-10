import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { CommentsService } from 'src/app/services/comments.service';
import * as deleteCommentDialogConstants from '../../../../../shared/constants/delete-comment-dialog.constants';

@Component({
  selector: 'app-delete-comment-dialog',
  templateUrl: './delete-comment-dialog.component.html',
  styleUrls: ['./delete-comment-dialog.component.scss']
})
export class DeleteCommentDialogComponent implements OnInit {
  deleteCommentDialogConstants = deleteCommentDialogConstants;
  commentId!: number;
  topicId!: number;
  userId = sessionStorage.getItem('userId');

  constructor(private dialogRef: MatDialogRef<DeleteCommentDialogComponent>,
    @Inject (MAT_DIALOG_DATA) public data: {commentId: number, topicId: number},
    private commentsService: CommentsService,
    private router: Router) { 
      this.commentId = data.commentId;
      this.topicId = data.topicId;
    }

  ngOnInit(): void {
  }

  onSubmit(){
    this.commentsService.deleteComment(this.commentId, this.userId!)
    .pipe(first())
    .subscribe(response => {
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/user', this.userId, 'forum', 'topics', this.topicId]);
        });

        this.dialogRef.close();
    });
  }

  onDecline(){
    this.dialogRef.close();
  }
}
