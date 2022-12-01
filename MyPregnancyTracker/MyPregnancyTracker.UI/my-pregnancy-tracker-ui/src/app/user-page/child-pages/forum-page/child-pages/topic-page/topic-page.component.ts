import { Component, OnInit } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute} from '@angular/router';
import { filter, first } from 'rxjs';
import { CommentModel } from 'src/app/models/comment.model';
import { TopicModel } from 'src/app/models/topic.model';
import { CommentsService } from 'src/app/services/comments.service';
import { TopicsService } from 'src/app/services/topics.service';
import * as topicPageConstants from '../../../../../shared/constants/topic-page.constants';
import { DeleteTopicDialogComponent } from '../delete-topic-dialog/delete-topic-dialog.component';
import { EditTopicBottomSheetComponent } from '../edit-topic-bottom-sheet/edit-topic-bottom-sheet.component';

@Component({
  selector: 'app-topic-page',
  templateUrl: './topic-page.component.html',
  styleUrls: ['./topic-page.component.scss']
})
export class TopicPageComponent implements OnInit {
  userId = sessionStorage.getItem('userId');
  topicId: number;
  topic!: TopicModel;
  userTopics: TopicModel[] = [];
  comments: CommentModel[] = [];
  topicPageConstants = topicPageConstants;
  showActionButtons = false;
  showCommentsSection = false;
  changeCommentsButtonArrow = false;

  constructor(private route: ActivatedRoute,
    private topicsService: TopicsService,
    private commentsService: CommentsService,
    private matDialog: MatDialog,
    private bottomSheet: MatBottomSheet) { 
    this.topicId = Number(this.route.snapshot.params['topicId']);

  }

  ngOnInit(): void {
    this.topicsService.getUserTopics(this.userId!)
    .pipe(filter(x => !!x), first())
    .subscribe(response => {
      this.userTopics = response;

      this.topicsService.getTopic(this.topicId)
      .pipe(filter(x => !!x), first())
      .subscribe(response => {
      this.topic = response;
      this.showActionButtons = this.userTopics.filter(t => t.id === this.topic.id).length > 0 ? true : false;
      });
    }); 

    this.commentsService.getAll(this.topicId)
    .pipe(filter(x => !!x), first())
    .subscribe(response => this.comments = response);

  }

  expandComments(){
    this.changeCommentsButtonArrow = !this.changeCommentsButtonArrow;
    this.showCommentsSection = !this.showCommentsSection;
  }

  toggleDeleteTopicDialog(){
    const config = new MatDialogConfig();
    config.data = {
      topicId: this.topicId,
      category: this.topic.category
    }

    this.matDialog.open(DeleteTopicDialogComponent, config);
  }

  openEditModal(){
    this.bottomSheet.open(EditTopicBottomSheetComponent, {data: {topic: this.topic}});
  }
}

