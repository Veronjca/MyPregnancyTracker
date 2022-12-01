import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddTopicModel } from '../models/add-topic.model';
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

  getAllTopics(category: number): Observable<TopicModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("category", category);

    return this.httpClient.get<TopicModel[]>(routes.GET_ALL_TOPICS_ENDPOINT,  {params: queryParams});
  }

  getUserTopics(userId: string): Observable<TopicModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId);

    return this.httpClient.get<TopicModel[]>(routes.GET_USER_TOPICS_ENDPOINT,  {params: queryParams});
  }

  deleteTopic(topicId: number): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("topicId", topicId);

    return this.httpClient.get<TopicModel[]>(routes.DELETE_TOPIC_ENDPOINT,  {params: queryParams});
  }

  editTopic(model: TopicModel): Observable<any>{
    return this.httpClient.put<any>(this.routes.EDIT_TOPIC_ENDPOINT, model);
  }

  addTopic(model: AddTopicModel): Observable<any>{
    return this.httpClient.post<any>(routes.ADD_TOPIC_ENDPOINT, model);
  }
}
