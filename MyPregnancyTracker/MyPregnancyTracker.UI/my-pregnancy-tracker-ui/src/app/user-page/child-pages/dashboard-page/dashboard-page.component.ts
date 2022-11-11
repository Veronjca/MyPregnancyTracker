import { Component, OnInit } from '@angular/core';
import * as dashboardConstants from '../../../shared/constants/dashboard.constants';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit {
  dashboardConstants = dashboardConstants;
  constructor() { }

  ngOnInit(): void {
  }

}
