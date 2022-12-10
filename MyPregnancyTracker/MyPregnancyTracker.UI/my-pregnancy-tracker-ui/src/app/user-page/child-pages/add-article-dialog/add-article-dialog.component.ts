import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AddArticleRequest } from 'src/app/models/add-article-request.model';
import { ArticlesService } from 'src/app/services/articles.service';
import * as addArticleDialogConstants from '../../../shared/constants/add-article-dialog.constants';

@Component({
  selector: 'app-add-article-dialog',
  templateUrl: './add-article-dialog.component.html',
  styleUrls: ['./add-article-dialog.component.scss']
})
export class AddArticleDialogComponent implements OnInit {
  addArticleDialogConstants = addArticleDialogConstants;
  userId = sessionStorage.getItem('userId');

  addArticleForm = new FormGroup({
    title: new FormControl('', Validators.required),
    content: new FormControl('', Validators.required)
  });

  constructor(private dialogRef: MatDialogRef<AddArticleDialogComponent>,
    private articlesService: ArticlesService,
    private router: Router) {}

  ngOnInit(): void {
  }

  addArticle(){
   const addArticleRequest: AddArticleRequest = {
      content: this.addArticleForm.controls.content.value!,
      title: this.addArticleForm.controls.title.value!,
      userId: this.userId!
    }

    this.articlesService.addArticle(addArticleRequest)
    .pipe(first())
    .subscribe(response => {
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/user', this.userId, 'articles']);
        });

        this.dialogRef.close();
    });
  
  }
}
