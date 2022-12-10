import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCommentRequest } from '../models/add-comment-request.model';
import { CommentModel } from '../models/comment.model';
import { GetAllCommentsRequest } from '../models/get-all-comments-request.model';
import { GetAllCommentsResponse } from '../models/get-all-comments-response.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  routes = routes;

  constructor(private httpClient: HttpClient) { }

  getAll(model: GetAllCommentsRequest): Observable<GetAllCommentsResponse>{
    return this.httpClient.post<GetAllCommentsResponse>(this.routes.GET_ALL_COMMENTS_ENDPOINT, model);
  }

  addComment(model: AddCommentRequest): Observable<any>{
    return this.httpClient.post<any>(this.routes.ADD_COMMENT_ENDPOINT, model);
  }

  getUserComments(topicId: number, userId: string): Observable<CommentModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('topicId', topicId);
    queryParams = queryParams.append('userId', userId);

    return this.httpClient.get<CommentModel[]>(this.routes.GET_USER_COMMENTS_ENDPOINT, {params: queryParams});
  }

  editComment(model: CommentModel, userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('userId', userId);

    return this.httpClient.put<any>(this.routes.EDIT_COMMENT_ENDPOINT, model, {params: queryParams});
  }

  deleteComment(commentId: number, userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('commentId', commentId);
    queryParams = queryParams.append('userId', userId);
  
    return this.httpClient.delete<any>(this.routes.DELETE_COMMENT_ENDPOINT, {params: queryParams});
  }
}
