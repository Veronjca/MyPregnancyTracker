import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Categories } from 'src/app/models/categories.enum';
import { AddTopicPageComponent } from './child-pages/add-topic-page/add-topic-page.component';

@Component({
  selector: 'app-forum-page',
  templateUrl: './forum-page.component.html',
  styleUrls: ['./forum-page.component.scss']
})
export class ForumPageComponent implements OnInit {
  userId = sessionStorage.getItem('userId');
  categories = Categories;

  constructor(private router: Router,
    private matDialog: MatDialog) { }

  ngOnInit(): void {
  }

  keys(): Array<string>{
    var keys = Object.keys(this.categories);
    return keys.slice(keys.length / 2);
  }

  navigateToTopics(category: any){
    const categoryId = Categories[category];

    this.router.navigate(['/user', this.userId, 'forum', 'topics'], {queryParams: {categoryId}});
  }

  openDialog(){
    this.matDialog.open(AddTopicPageComponent);
  }
}
