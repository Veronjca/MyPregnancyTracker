import { Component, OnInit } from '@angular/core';
import { Categories } from 'src/app/models/categories.enum';

@Component({
  selector: 'app-forum-dashboard-page',
  templateUrl: './forum-dashboard-page.component.html',
  styleUrls: ['./forum-dashboard-page.component.scss']
})
export class ForumDashboardPageComponent implements OnInit {
  categories = Object.keys(Categories);

  constructor() { }

  ngOnInit(): void {
  }

}
