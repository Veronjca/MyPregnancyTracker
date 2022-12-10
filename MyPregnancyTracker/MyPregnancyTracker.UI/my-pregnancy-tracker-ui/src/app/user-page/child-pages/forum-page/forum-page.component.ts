import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Categories } from 'src/app/models/categories.enum';
import { AddTopicPageComponent } from './child-pages/add-topic-page/add-topic-page.component';
import * as forumPageConstants from '../../../shared/constants/forum-page.constants';

@Component({
  selector: 'app-forum-page',
  templateUrl: './forum-page.component.html',
  styleUrls: ['./forum-page.component.scss']
})
export class ForumPageComponent implements OnInit {
  forumPageConstants = forumPageConstants;
  userId = sessionStorage.getItem('userId');
  categories = Categories;

  constructor(private router: Router,
    private matDialog: MatDialog,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  keys(): Array<string>{
    var keys = Object.keys(this.categories);
    return keys.slice(keys.length / 2);
  }

  navigateToTopics(category: any){
    const categoryId = Categories[category];

    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/user', this.userId, 'forum', 'topics'], {queryParams: {category: categoryId}});
    });
  }

  openDialog(){
    this.matDialog.open(AddTopicPageComponent);
  }

  get showAddButton(): Observable<boolean>{
    return of(this.route.firstChild?.firstChild?.snapshot.params['topicId']);     
  }
}
