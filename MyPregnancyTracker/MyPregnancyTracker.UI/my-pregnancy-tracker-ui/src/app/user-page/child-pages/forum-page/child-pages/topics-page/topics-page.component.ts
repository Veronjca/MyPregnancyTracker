import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { filter, first } from 'rxjs';
import { TopicsService } from 'src/app/services/topics.service';
import { TopicModel } from 'src/app/models/topic.model';
import * as topicPageConstants from '../../../../../shared/constants/topics-page.constants';
import {  MatTableDataSource } from '@angular/material/table';
import { Categories } from 'src/app/models/categories.enum';

@Component({
  selector: 'app-topics-page',
  templateUrl: './topics-page.component.html',
  styleUrls: ['./topics-page.component.scss']
})
export class TopicsPageComponent implements OnInit {
  topicPageConstants = topicPageConstants;
  userId = sessionStorage.getItem('userId');
  categories = Categories;
  category!: number;
  categoryString = '';
  dataSource = new MatTableDataSource();
  displayedColumns = ['title', 'author', 'createdOn', 'category'];

  constructor(private route: ActivatedRoute,
    private topicsService: TopicsService,
    private router: Router) {
   
   }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.category = Number(params['category']);
    });

    this.topicsService.getAllTopics(this.category)
                      .pipe(filter(x => !!x),first())
                      .subscribe(response => this.dataSource.data = response);

    this.categoryString = this.categories[this.category];
  }

  navigateToTopicPage(topic: TopicModel){
    this.router.navigate(['/user', this.userId, 'forum', 'topics', topic.id])
  }
}
