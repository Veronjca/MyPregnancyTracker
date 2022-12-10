import { AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { filter, first } from 'rxjs';
import { TopicsService } from 'src/app/services/topics.service';
import { TopicModel } from 'src/app/models/topic.model';
import * as topicPageConstants from '../../../../../shared/constants/topics-page.constants';
import {  MatTableDataSource } from '@angular/material/table';
import { Categories } from 'src/app/models/categories.enum';
import { MatPaginator } from '@angular/material/paginator';
import { GetAllTopicsRequest } from 'src/app/models/get-all-topics-request.model';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-topics-page',
  templateUrl: './topics-page.component.html',
  styleUrls: ['./topics-page.component.scss']
})
export class TopicsPageComponent implements OnInit, AfterViewInit, AfterViewChecked {
  topicPageConstants = topicPageConstants;
  userId = sessionStorage.getItem('userId');
  categories = Categories;
  category!: number;
  paginatorLength: number = 0;
  categoryString = '';
  getAllTopicsModel!: GetAllTopicsRequest;
  initialGetAllTopicsModel: GetAllTopicsRequest = {
      category: this.category,
      isDescendingOrder: false,
      skip: 0,
      take: 5
  };

  dataSource = new MatTableDataSource();
  displayedColumns = ['title', 'author', 'createdOn', 'category'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  

  constructor(private route: ActivatedRoute,
    private topicsService: TopicsService,
    private router: Router) {
   
   }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngAfterViewChecked(): void {
    if(!!this.paginator){
      const paginatorIntl = this.paginator._intl;
      paginatorIntl.nextPageLabel = 'Следваща страница';
      paginatorIntl.previousPageLabel = 'Предишна страница';
      paginatorIntl.lastPageLabel = 'Последна страница';
      paginatorIntl.firstPageLabel = 'Първа страница';
    }
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.category = Number(params['category']);
    });

    this.initialGetAllTopicsModel.category = this.category;

    this.getAllTopicsModel = {
      ...this.initialGetAllTopicsModel
    };

    this.getAllTopics(this.getAllTopicsModel);

    this.categoryString = this.categories[this.category];
  }

  navigateToTopicPage(topic: TopicModel){
    this.router.navigate(['/user', this.userId, 'forum', 'topics', topic.id])
  }

  onPageChange(){
    this.getAllTopicsModel = {
      ...this.getAllTopicsModel,
      skip: this.paginator.pageIndex * this.paginator.pageSize,
      take: this.paginator.pageSize
    }

    this.getAllTopics(this.getAllTopicsModel);
  }

  sortData(sort: Sort){
    this.getAllTopicsModel = {
      ...this.initialGetAllTopicsModel,
      isDescendingOrder: sort.direction === 'desc'
    }

    this.getAllTopics(this.getAllTopicsModel);
    this.paginator.firstPage();

  }

  private getAllTopics(requestModel: GetAllTopicsRequest){
    this.topicsService.getAllTopics(requestModel)
    .pipe(filter(x => !!x),first())
    .subscribe(response => {
      this.dataSource.data = response.topics;
      this.paginatorLength = response.topicsCount;
    });
  }
}
