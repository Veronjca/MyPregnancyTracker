import { DialogRef } from '@angular/cdk/dialog';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';
import { AddTopicModel } from 'src/app/models/add-topic.model';
import { Categories } from 'src/app/models/categories.enum';
import { TopicsService } from 'src/app/services/topics.service';
import * as constants from '../../../../../shared/constants/add-topic-page.constants';

@Component({
  selector: 'app-add-topic-page',
  templateUrl: './add-topic-page.component.html',
  styleUrls: ['./add-topic-page.component.scss']
})
export class AddTopicPageComponent implements OnInit {
  constants = constants;
  categories = Categories;
  addTopicModel!: AddTopicModel;
  userId = sessionStorage.getItem('userId');

  addTopicForm = new FormGroup({
    category: new FormControl('', Validators.required),
    title: new FormControl('', Validators.required),
    content: new FormControl('', [Validators.required, Validators.maxLength(2000)])
  });

  constructor(private dialogRef: DialogRef<AddTopicPageComponent>,
    private topicsService: TopicsService) { }

  ngOnInit(): void {
  }

  keys(): Array<string>{
    var keys = Object.keys(this.categories);
    return keys.slice(keys.length / 2);
  }

  addTopic(){
    const input: any = this.addTopicForm.value.category;
    const category = Categories[input!];

    this.addTopicModel = {
      title: this.addTopicForm.value.title!,
      userId: this.userId!,
      content: this.addTopicForm.value.content!,
      category: Number(category)
    }

    this.topicsService.addTopic(this.addTopicModel).pipe(first()).subscribe();
    this.dialogRef.close();
  }
}
