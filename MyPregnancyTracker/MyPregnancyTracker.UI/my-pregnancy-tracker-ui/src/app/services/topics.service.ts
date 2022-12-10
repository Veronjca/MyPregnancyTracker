import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTopicModel } from '../models/add-topic.model';
import { GetAllTopicsRequest } from '../models/get-all-topics-request.model';
import { GetAllTopicsResponse } from '../models/get-all-topics-response.model';
import { TopicModel } from '../models/topic.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class TopicsService {
  routes = routes;

  constructor(private httpClient: HttpClient) { }

  getTopic(topicId: number): Observable<TopicModel>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("topicId", topicId);

    return this.httpClient.get<TopicModel>(routes.GET_TOPIC_ENDPOINT,  {params: queryParams});
  }

  getAllTopics(model: GetAllTopicsRequest): Observable<GetAllTopicsResponse>{
    return this.httpClient.post<GetAllTopicsResponse>(routes.GET_ALL_TOPICS_ENDPOINT,  model);
  }

  getUserTopics(userId: string): Observable<TopicModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId);

    return this.httpClient.get<TopicModel[]>(routes.GET_USER_TOPICS_ENDPOINT,  {params: queryParams});
  }

  deleteTopic(topicId: number, userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("topicId", topicId);
    queryParams = queryParams.append("userId", userId);

    return this.httpClient.delete<any>(routes.DELETE_TOPIC_ENDPOINT,  {params: queryParams});
  }

  editTopic(model: TopicModel, userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append('userId', userId);

    return this.httpClient.put<any>(this.routes.EDIT_TOPIC_ENDPOINT, model, {params: queryParams});
  }

  addTopic(model: AddTopicModel): Observable<any>{
    return this.httpClient.post<any>(routes.ADD_TOPIC_ENDPOINT, model);
  }
}
