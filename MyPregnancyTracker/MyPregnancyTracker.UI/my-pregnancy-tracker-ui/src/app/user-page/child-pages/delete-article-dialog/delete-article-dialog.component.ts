import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { ArticleModel } from 'src/app/models/article.model';
import { ArticlesService } from 'src/app/services/articles.service';
import * as deleteArticleDialogConstants from '../../../shared/constants/delete-article-dialog.constants';

@Component({
  selector: 'app-delete-article-dialog',
  templateUrl: './delete-article-dialog.component.html',
  styleUrls: ['./delete-article-dialog.component.scss']
})
export class DeleteArticleDialogComponent implements OnInit {
  deleteArticleDialogConstants = deleteArticleDialogConstants;
  userId: string = '';
  articleId!: number;

  constructor(@Inject (MAT_DIALOG_DATA) data: {article: ArticleModel, userId: string},
  private dialogRef: MatDialogRef<DeleteArticleDialogComponent>,
  private articlesService: ArticlesService,
  private router: Router) { 
    this.userId = data.userId;
    this.articleId = data.article.id;
  }

  ngOnInit(): void {
  }

  onSubmit(){
    this.articlesService.deleteArticle(this.articleId!, this.userId)
    .pipe(first())
    .subscribe(response => {
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/user', this.userId, 'articles']);
        });

        this.dialogRef.close();
    });

    
  }

  onDecline(){
    this.dialogRef.close();
  }

}
