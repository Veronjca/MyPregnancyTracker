import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskModel } from '../models/task.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  routes = routes;
  constructor(private httpClient: HttpClient) { }

  getUserTasks(userId: string): Observable<TaskModel[]>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId);

    return this.httpClient.get<TaskModel[]>(this.routes.GET_USER_TASKS_ENDPOINT, {params: queryParams});
  }
}
