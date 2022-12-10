import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddDeleteReactionRequest } from '../models/add-delete-reaction-request.model';
import { AddDeleteReactionResponse } from '../models/add-delete-reaction-response.model';
import { ReactionModel } from '../models/reaction.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class ReactionsService {
  routes = routes;

  constructor(private httpClient: HttpClient) { }

  getUserReactions(userId: string): Observable<ReactionModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('userId', userId);

    return this.httpClient.get<ReactionModel[]>(this.routes.GET_USER_REACTIONS_ENDPOINT, {params: queryParams});
  }

  addReaction(model: AddDeleteReactionRequest): Observable<AddDeleteReactionResponse>{
    return this.httpClient.post<AddDeleteReactionResponse>(routes.ADD_REACTION_ENDPOINT, model);
  }

  deleteReaction(model: AddDeleteReactionRequest): Observable<AddDeleteReactionResponse>{
    return this.httpClient.post<AddDeleteReactionResponse>(routes.DELETE_REACTION_ENDPOINT, model);
  }
}
