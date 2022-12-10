import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { first } from 'rxjs';
import { CommentModel } from 'src/app/models/comment.model';
import { CommentsService } from 'src/app/services/comments.service';
import * as constants from '../../../../../shared/constants/edit-comment-bottom-sheet.constants';

@Component({
  selector: 'app-edit-comment-bottom-sheet',
  templateUrl: './edit-comment-bottom-sheet.component.html',
  styleUrls: ['./edit-comment-bottom-sheet.component.scss']
})
export class EditCommentBottomSheetComponent implements OnInit {
  constants = constants;
  userId = sessionStorage.getItem('userId');
  comment!: CommentModel;
  commentFormControl = new FormControl('');

  constructor(private bottomSheetRef: MatBottomSheetRef,
    @Inject (MAT_BOTTOM_SHEET_DATA) public data: {comment: CommentModel},
    private commentsService: CommentsService) { 
      this.comment = data.comment;
      this.commentFormControl.setValue(this.comment.content);
    }

  ngOnInit(): void {
  }

  editComment(){
    this.comment.content = this.commentFormControl.value!;

    this.commentsService.editComment(this.comment, this.userId!)
    .pipe(first())
    .subscribe();

    this.bottomSheetRef.dismiss();
  }
}
