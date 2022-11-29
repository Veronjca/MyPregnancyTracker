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

  getAllTopics(categoryId: number): Observable<TopicModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("categoryId", categoryId);

    return this.httpClient.get<TopicModel[]>(routes.GET_ALL_TOPICS_ENDPOINT,  {params: queryParams});
  }

  addTopic(model: AddTopicModel): Observable<any>{
    return this.httpClient.post<any>(routes.ADD_TOPIC_ENDPOINT, model);
  }
}
