import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { first } from 'rxjs';
import { ArticleModel } from 'src/app/models/article.model';
import { EditArticleRequest } from 'src/app/models/edit-article-request.model';
import { ArticlesService } from 'src/app/services/articles.service';
import * as editArticleBottomSheetConstants from '../../../shared/constants/edit-article-bottom-sheet.constants';

@Component({
  selector: 'app-edit-article-bottom-sheet',
  templateUrl: './edit-article-bottom-sheet.component.html',
  styleUrls: ['./edit-article-bottom-sheet.component.scss']
})
export class EditArticleBottomSheetComponent implements OnInit {
  editArticleBottomSheetConstants = editArticleBottomSheetConstants;
  userId: string = '';
  article!: ArticleModel;

  editArticleForm = new FormGroup({
    title: new FormControl('', Validators.required),
    content: new FormControl('', Validators.required)
  });

  constructor(@Inject (MAT_BOTTOM_SHEET_DATA) data: {article: ArticleModel, userId: string},
  private bottomSheetRef: MatBottomSheetRef<EditArticleBottomSheetComponent>,
  private articlesService: ArticlesService) { 
    this.userId = data.userId;
    this.article = data.article;

    this.editArticleForm.controls.content.setValue(data.article.content);
    this.editArticleForm.controls.title.setValue(data.article.title);
  }

  ngOnInit(): void {
  }

  editArticle(){
   const editArticleRequest: EditArticleRequest = {
    id: this.article.id,
    content: this.editArticleForm.controls.content.value!,
    title: this.editArticleForm.controls.title.value!
   };

    this.article.content = this.editArticleForm.controls.content.value!;
    this.article.title = this.editArticleForm.controls.title.value!;

    this.articlesService.editArticle(editArticleRequest, this.userId)
    .pipe(first())
    .subscribe(response => this.bottomSheetRef.dismiss());
  }
}
