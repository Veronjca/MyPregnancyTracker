import { AfterViewChecked, Component, OnInit, ViewChild } from '@angular/core';
import { filter, first } from 'rxjs';

import { MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatBottomSheet, MatBottomSheetConfig } from '@angular/material/bottom-sheet';

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
export class ArticlesPageComponent implements OnInit, AfterViewChecked {
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
      take: 5
    }

    this.getAllArticles(this.getAllArticlesRequest);
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

  private getAllArticles(model: GetAllArticlesRequest){
    this.articlesService.getAllArticles(model)
    .pipe(filter(x => !!x), first())
    .subscribe(response => {
      this.dataSource.data = response.articles,
      this.paginatorLength = response.articlesCount;
    })
  }

  onPageChange(){
    this.getAllArticlesRequest = {
      ...this.getAllArticlesRequest,
      skip: this.paginator.pageIndex * this.paginator.pageSize,
      take: this.paginator.pageSize
    }

    this.getAllArticles(this.getAllArticlesRequest);
  }

  openDeleteArticleDialog(article: ArticleModel){
    let config = new MatDialogConfig();
    config.data = {
      userId: this.userId,
      article: article
    }

    this.dialog.open(DeleteArticleDialogComponent, config);
  }

  openEditArticleBottomSheet(article: ArticleModel){
    let config = new MatBottomSheetConfig();
    config.data = {
      userId: this.userId,
      article: article
    }

    this.bottomSheet.open(EditArticleBottomSheetComponent, config);
  }

  openAddArticleDialog(){
    this.dialog.open(AddArticleDialogComponent);
  }
}
