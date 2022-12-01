import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentModel } from '../models/comment.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  routes = routes;

  constructor(private httpClient: HttpClient) { }

  getAll(topicId: number): Observable<CommentModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('topicId', topicId);

    return this.httpClient.get<CommentModel[]>(this.routes.GET_ALL_COMMENTS_ENDPOINT, {params: queryParams});
  }
}
