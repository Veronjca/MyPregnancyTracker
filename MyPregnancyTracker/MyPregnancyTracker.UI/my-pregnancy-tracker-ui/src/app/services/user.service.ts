import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetUserProfileDataResponse } from '../models/get-user-profile-data-response.model';
import { UpdateUserProfileRequest } from '../models/update-user-profile-request.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  routes = routes;
  constructor(private httpClient: HttpClient) { }

  updateUserProfile(model: UpdateUserProfileRequest): Observable<any>{
    return this.httpClient.post<any>(routes.UPDATE_USER_PROFILE_ENDPOINT, model);
  }

  getUserProfileData(): Observable<GetUserProfileDataResponse>{
    const userId = sessionStorage.getItem('userId')
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId!);

    return this.httpClient.get<GetUserProfileDataResponse>(routes.GET_USER_PROFILE_DATA_ENDPOINT, {params: queryParams});
  }

  addTask(userId: string, taskId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId!);
    queryParams = queryParams.append("taskId", taskId!);
   
    return this.httpClient.post<any>(routes.ADD_TASK_ENDPOINT, null, {params: queryParams});
  }

  removeTask(userId: string, taskId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId!);
    queryParams = queryParams.append("taskId", taskId!);
   
    return this.httpClient.post<any>(routes.REMOVE_TASK_ENDPOINT, null, {params: queryParams});
  }

  setGestationalWeek(userId: string): Observable<any>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId", userId!);

    return this.httpClient.get<any>(routes.SET_GESTATIONAL_WEEK_ENDPOINT, {params: queryParams});
  }
}

