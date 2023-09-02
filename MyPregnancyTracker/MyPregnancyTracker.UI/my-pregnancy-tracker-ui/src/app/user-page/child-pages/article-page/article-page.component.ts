import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
export class ArticlePageComponent implements OnInit{
  userId = sessionStorage.getItem('userId');
  articleId = this.route.snapshot.params['articleId'];
  article!: ArticleModel;
  articlePageConstants = articlePageConstants;

 constructor(private articlesService: ArticlesService,
  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.articlesService.getOne(this.articleId, this.userId!).subscribe(article => this.article = article);
  }

addReaction(isLiked: boolean, article: ArticleModel){
  const addReactionToArticleRequest: AddReactionToArticleRequest = {
    isLiked: article.isLiked == isLiked ? null : isLiked,
    articleId: article.id,
    userId: this.userId!
  };

  this.articlesService.addReaction(addReactionToArticleRequest)
  .pipe(first())
  .subscribe(article => this.article = article);
  }

}
