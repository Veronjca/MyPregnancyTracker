import { Component } from '@angular/core';
import { first } from 'rxjs';

import { AddReactionToArticleRequest } from 'src/app/models/add-reaction-to-article-request.model';
import { ArticleModel } from 'src/app/models/article.model';
import { ArticlesService } from 'src/app/services/articles.service';
import * as articlePageConstants from "src/app/shared/constants/article-page.constants";

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.scss']
})
export class ArticlePageComponent {
  userId = sessionStorage.getItem('userId');
  articlePageConstants = articlePageConstants;

 constructor(private articlesService: ArticlesService) { }

addReaction(isLiked: boolean, article: ArticleModel){
  const addReactionToArticleRequest: AddReactionToArticleRequest = {
    isLiked: article.isLiked == isLiked ? null : isLiked,
    articleId: article.id,
    userId: this.userId!
  };

  this.articlesService.addReaction(addReactionToArticleRequest)
  .pipe(first())
  .subscribe();
  }

}
