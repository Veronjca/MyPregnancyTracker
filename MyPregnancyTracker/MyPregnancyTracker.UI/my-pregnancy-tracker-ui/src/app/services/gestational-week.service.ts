import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GestationalWeek } from '../models/gestational-week.model';
import * as routes from '../shared/constants/routes.constants';

@Injectable({
  providedIn: 'root'
})
export class GestationalWeekService {
  routes = routes;

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<GestationalWeek[]>{
      return this.httpClient.get<GestationalWeek[]>(this.routes.GET_ALL_ENDPOINT);
  }
}
