import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddArticleRequest } from '../models/add-article-request.model';
import { AddReactionToArticleRequest } from '../models/add-reaction-to-article-request.model';
import { AddReactionToArticleResponse } from '../models/add-reaction-to-article-response.model';
import { ArticleModel } from '../models/article.model';
import { EditArticleRequest } from '../models/edit-article-request.model';
import { GetAllArticlesRequest } from '../models/get-all-articles-request.models';
import { GetAllArticlesResponse } from '../models/get-all-articles-response.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  routes = routes;

  constructor(private httpClient: HttpClient) { }

  getAllArticles(model: GetAllArticlesRequest): Observable<GetAllArticlesResponse>{
    return this.httpClient.post<GetAllArticlesResponse>(this.routes.GET_ALL_ARTICLES_ENDPOINT, model);
  }

  deleteArticle(articleId: number, userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('articleId', articleId);
    queryParams = queryParams.append('userId', userId);

    return this.httpClient.delete<any>(this.routes.DELETE_ARTICLE_ENDPOINT, {params: queryParams});
  }

  editArticle(model: EditArticleRequest, userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('userId', userId);

    return this.httpClient.put<any>(this.routes.EDIT_ARTICLE_ENDPOINT, model, {params: queryParams});
  }

  addReaction(model: AddReactionToArticleRequest): Observable<AddReactionToArticleResponse>{
    return this.httpClient.post<AddReactionToArticleResponse>(this.routes.ADD_REACTION_TO_ARTICLE_ENDPOINT, model);
  }

  addArticle(model: AddArticleRequest): Observable<any>{
    return this.httpClient.post<any>(this.routes.ADD_ARTICLE_ENDPOINT, model);
  }
}
