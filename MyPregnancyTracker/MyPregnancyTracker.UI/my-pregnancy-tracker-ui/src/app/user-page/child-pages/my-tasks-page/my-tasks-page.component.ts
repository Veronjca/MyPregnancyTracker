import { Component, OnInit, ViewChild } from '@angular/core';
import { MatCheckbox } from '@angular/material/checkbox';
import { filter, first, of } from 'rxjs';
import { TaskModel } from 'src/app/models/task.model';
import { TaskService } from 'src/app/services/tasks.service';
import { UserService } from 'src/app/services/user.service';
import * as myTasksPageConstants from '../../../shared/constants/my-tasks-page.constants';

@Component({
  selector: 'app-my-tasks-page',
  templateUrl: './my-tasks-page.component.html',
  styleUrls: ['./my-tasks-page.component.scss']
})
export class MyTasksPageComponent implements OnInit {
  myTasksPageConstants = myTasksPageConstants;
  userId = sessionStorage.getItem('userId');
  gestationalWeekAge = Number(sessionStorage.getItem('gestationalWeekAge'));
  allTasks!: TaskModel[];

  constructor(private taskService: TaskService,
    private userService: UserService) { 
  }

  ngOnInit(): void {
    this.taskService.getAllTasks(this.gestationalWeekAge!, this.userId!)
                    .pipe(filter(x => !!x), first())
                    .subscribe(response => this.allTasks = response);
  }

  onChange(checkbox: MatCheckbox, taskId: string){
    if(checkbox.checked){
      this.userService.addTask(this.userId!, taskId).pipe(first()).subscribe();
    }else{
      this.userService.removeTask(this.userId!, taskId).pipe(first()).subscribe();
    }   
  }

}

