import { Component, OnInit } from '@angular/core';
import { filter, first } from 'rxjs';
import { TaskModel } from 'src/app/models/task.model';
import { TaskService } from 'src/app/services/tasks.service';
import * as myTasksPageConstants from '../../../shared/constants/my-tasks-page.constants';

@Component({
  selector: 'app-my-tasks-page',
  templateUrl: './my-tasks-page.component.html',
  styleUrls: ['./my-tasks-page.component.scss']
})
export class MyTasksPageComponent implements OnInit {
  myTasksPageConstants = myTasksPageConstants;
  userId = sessionStorage.getItem('userId');
  tasks!: TaskModel[];

  constructor(private taskService: TaskService) { 
  }

  ngOnInit(): void {
    this.taskService.getUserTasks(this.userId!).pipe(filter(x => !!x), first()).subscribe(response => this.tasks = response);
  }

}

