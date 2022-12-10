import { AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet, MatBottomSheetConfig } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute} from '@angular/router';
import { filter, first, Observable, of, Subscription} from 'rxjs';
import { AddDeleteReactionRequest } from 'src/app/models/add-delete-reaction-request.model';
import { CommentModel } from 'src/app/models/comment.model';
import { GetAllCommentsRequest } from 'src/app/models/get-all-comments-request.model';
import { ReactionModel } from 'src/app/models/reaction.model';
import { TopicModel } from 'src/app/models/topic.model';
import { CommentsService } from 'src/app/services/comments.service';
import { ReactionsService } from 'src/app/services/reactions.service';
import { TopicsService } from 'src/app/services/topics.service';
import * as topicPageConstants from '../../../../../shared/constants/topic-page.constants';
import { AddCommentDialogComponent } from '../add-comment-dialog/add-comment-dialog.component';
import { DeleteCommentDialogComponent } from '../delete-comment-dialog/delete-comment-dialog.component';
import { DeleteTopicDialogComponent } from '../delete-topic-dialog/delete-topic-dialog.component';
import { EditCommentBottomSheetComponent } from '../edit-comment-bottom-sheet/edit-comment-bottom-sheet.component';
import { EditTopicBottomSheetComponent } from '../edit-topic-bottom-sheet/edit-topic-bottom-sheet.component';

@Component({
  selector: 'app-topic-page',
  templateUrl: './topic-page.component.html',
  styleUrls: ['./topic-page.component.scss']
})
export class TopicPageComponent implements OnInit, AfterViewInit, AfterViewChecked {
  userId = sessionStorage.getItem('userId');
  topicPageConstants = topicPageConstants;
  subs: Subscription[] = [];

  topicId: number;
  topic!: TopicModel;
  paginatorLength: number = 0;

  userTopics: TopicModel[] = [];
  dataSource: MatTableDataSource<CommentModel> = new MatTableDataSource<CommentModel>();
  userComments: CommentModel[] = [];
  userReactions: ReactionModel[] = [];
  getAllCommentsRequest!: GetAllCommentsRequest;
  addDeleteReactionRequest!: AddDeleteReactionRequest;

  showActionButtons = false;
  showCommentsSection = false;
  changeCommentsButtonArrow = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private route: ActivatedRoute,
    private topicsService: TopicsService,
    private commentsService: CommentsService,
    private reactionsService: ReactionsService,
    private matDialog: MatDialog,
    private bottomSheet: MatBottomSheet) { 
    this.topicId = Number(this.route.snapshot.params['topicId']);

  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  ngAfterViewChecked(): void {
    if(!!this.paginator){
      const paginatorIntl = this.paginator._intl;
      paginatorIntl.nextPageLabel = 'Следваща страница';
      paginatorIntl.previousPageLabel = 'Предишна страница';
      paginatorIntl.lastPageLabel = 'Последна страница';
      paginatorIntl.firstPageLabel = 'Първа страница';
    }
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

    this.getAllCommentsRequest = {
      topicId: this.topicId,
      skip: 0,
      take: 5
    };

    this.commentsService.getAll(this.getAllCommentsRequest)
    .pipe(filter(x => !!x), first())
    .subscribe(response => {
      this.dataSource.data = response.comments;
      this.paginatorLength = response.commentsCount;
    });

    this.commentsService.getUserComments(this.topicId, this.userId!)
    .pipe(filter(x => !!x), first())
    .subscribe(response => this.userComments = response);

    this.reactionsService.getUserReactions(this.userId!)
    .pipe(filter(x => !!x), first())
    .subscribe(response => this.userReactions = response);
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

  openEditTopicModal(){
    this.bottomSheet.open(EditTopicBottomSheetComponent, {data: {topic: this.topic}});
  }

  openAddCommentDialog(){
    const config = new MatDialogConfig();
    config.data = {
      topicId: this.topicId,
      userId: this.userId
    }

    this.matDialog.open(AddCommentDialogComponent, config);
  }

  isUserComment(comment: CommentModel): boolean{
    return this.userComments.filter(c => c.id == comment.id).length > 0;
  }

  openEditCommentBottomSheet(comment: CommentModel){
    const config = new MatBottomSheetConfig();
    config.data = {
      comment: comment
    }

    this.bottomSheet.open(EditCommentBottomSheetComponent, config);
  }

  openDeleteCommentDialog(comment: CommentModel){
    const config = new MatDialogConfig();
    config.data = {
      commentId: comment.id,
      topicId: this.topicId 
    }

    this.matDialog.open(DeleteCommentDialogComponent, config);
  }

  getReactionCount(comment: CommentModel, reactionType: string): Observable<number>{
      return of(comment.reactions.filter(c => c.type == reactionType).length);
  }

  isOutlined(reactionType: string, comment: CommentModel): Observable<string>{

    if(reactionType == 'Love'){
      if(this.userReactions.filter(r => r.type == reactionType && r.commentId == comment.id).length > 0){
        return of('favorite');
      }
      return of('favorite_border');

    }else if(reactionType == 'Like'){
      if(this.userReactions.filter(r => r.type == reactionType && r.commentId == comment.id).length > 0){
        return of('thumb_up_alt');
      }
      return of('thumb_up_off_alt');

    }else if(reactionType == 'Sad'){
      if(this.userReactions.filter(r => r.type == reactionType && r.commentId == comment.id).length > 0){
        return of('material-symbols-outlined');
      }
      return of('material-icons-outlined');
    }

    if(this.userReactions.filter(r => r.type == reactionType && r.commentId == comment.id).length > 0){
      return of('material-icons');
    }
    return of('material-icons-outlined');
  }

  onReactionClick(reactionType: string, comment: CommentModel){
    this.addDeleteReactionRequest = {
      ...this.getAllCommentsRequest,
      reactionType: reactionType,
      commentId: comment.id,
      userId: this.userId!
    }

    if(this.userReactions.filter(r => r.type == reactionType && r.commentId == comment.id).length > 0 ){
      this.reactionsService.deleteReaction(this.addDeleteReactionRequest)
      .pipe(first())
      .subscribe(response => {
          this.dataSource.data = response.topicComments.comments;
          this.paginatorLength = response.topicComments.commentsCount;
          this.userReactions = response.userReactions; 
      });

    }else {
      this.reactionsService.addReaction(this.addDeleteReactionRequest)
      .pipe(first())
      .subscribe(response => {
          this.dataSource.data = response.topicComments.comments;
          this.paginatorLength = response.topicComments.commentsCount;
          this.userReactions = response.userReactions;
      });
    }
  }

  onPageChange(){
    this.getAllCommentsRequest = {
      ...this.getAllCommentsRequest,
      skip: this.paginator.pageIndex * this.paginator.pageSize,
      take: this.paginator.pageSize
    }

    this.commentsService.getAll(this.getAllCommentsRequest)
    .pipe(filter(x => !!x), first())
    .subscribe(response => {
      this.dataSource.data = response.comments;
      this.paginatorLength = response.commentsCount;
    });

  }

}

