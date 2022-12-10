import { Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet, MatBottomSheetConfig } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { filter, first } from 'rxjs';
import { AddReactionToArticleRequest } from 'src/app/models/add-reaction-to-article-request.model';
import { ArticleModel } from 'src/app/models/article.model';
import { GetAllArticlesRequest } from 'src/app/models/get-all-articles-request.models';
import { ArticlesService } from 'src/app/services/articles.service';
import { AuthService } from 'src/app/services/auth.service';
import * as articlesPageConstants from '../../../shared/constants/articles-page.constants';
import { AddArticleDialogComponent } from '../add-article-dialog/add-article-dialog.component';
import { DeleteArticleDialogComponent } from '../delete-article-dialog/delete-article-dialog.component';
import { EditArticleBottomSheetComponent } from '../edit-article-bottom-sheet/edit-article-bottom-sheet.component';

@Component({
  selector: 'app-articles-page',
  templateUrl: './articles-page.component.html',
  styleUrls: ['./articles-page.component.scss']
})
export class ArticlesPageComponent implements OnInit {
  articlesPageConstants = articlesPageConstants;
  userId = sessionStorage.getItem('userId');
  paginatorLength: number = 0;
  dataSource: MatTableDataSource<ArticleModel> = new MatTableDataSource<ArticleModel>();

  getAllArticlesRequest!: GetAllArticlesRequest;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private articlesService: ArticlesService,
    private dialog: MatDialog,
    private bottomSheet: MatBottomSheet,
    public authService: AuthService) { }

  ngOnInit(): void {
    this.getAllArticlesRequest = {
      userId: this.userId!,
      skip: 0,
      take: 1
    }

    this.getAllArticles(this.getAllArticlesRequest);
  }

  onPageChange(){
    this.getAllArticlesRequest = {
      ...this.getAllArticlesRequest,
      skip: this.paginator.pageIndex * this.paginator.pageSize,
      take: this.paginator.pageSize
    }

    this.getAllArticles(this.getAllArticlesRequest);
  }

  openEditArticleBottomSheet(article: ArticleModel){
    let config = new MatBottomSheetConfig();
    config.data = {
      userId: this.userId,
      article: article
    }

    this.bottomSheet.open(EditArticleBottomSheetComponent, config);
  }

  openDeleteArticleDialog(article: ArticleModel){
    let config = new MatDialogConfig();
    config.data = {
      userId: this.userId,
      article: article
    }

    this.dialog.open(DeleteArticleDialogComponent, config);
  }

  private getAllArticles(model: GetAllArticlesRequest){
    this.articlesService.getAllArticles(model)
    .pipe(filter(x => !!x), first())
    .subscribe(response => {
      this.dataSource.data = response.articles,
      this.paginatorLength = response.articlesCount;
    })
  }

  addReaction(isLiked: boolean, article: ArticleModel){
    const addReactionToArticleRequest: AddReactionToArticleRequest = {
      isLiked: article.isLiked == isLiked ? null : isLiked,
      skip: this.paginator.pageSize * this.paginator.pageIndex,
      take: this.paginator.pageSize,
      articleId: article.id,
      userId: this.userId!
    };

    this.articlesService.addReaction(addReactionToArticleRequest)
    .pipe(first())
    .subscribe(response => this.dataSource.data = response.articles);
  }

  openAddArticleDialog(){
    this.dialog.open(AddArticleDialogComponent);
  }
}
