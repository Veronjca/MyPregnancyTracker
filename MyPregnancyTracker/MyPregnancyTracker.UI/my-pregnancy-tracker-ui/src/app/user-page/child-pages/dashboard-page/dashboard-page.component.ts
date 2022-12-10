import { Component, OnInit } from '@angular/core';
import { filter, first } from 'rxjs';
import { GestationalWeek } from 'src/app/models/gestational-week.model';
import { GestationalWeekService } from 'src/app/services/gestational-week.service';
import {MatDialog, MatDialogConfig } from '@angular/material/dialog';
import * as dashboardConstants from '../../../shared/constants/dashboard.constants';
import { AdditionalInfoDialogComponent } from '../additional-info-dialog/additional-info-dialog.component';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit {
  dashboardConstants = dashboardConstants;
  gestationalWeekAge = Number(sessionStorage.getItem('gestationalWeekAge'));
  index = 0;
  gestationalWeeks: GestationalWeek[] = [];

  adivecesTitle = 'СЪВЕТИ';
  advicesPictureUrl = '../../assets/images/advices-picture.jpg';
  nutritionTitle = 'ХРАНЕНЕ';
  nutritionPictureUrl = '../../assets/images/nutrition-picture.jpg';
  motherTitle = 'МАМА';
  motherPictureUrl = '../../assets/images/mother-picture.jpg';
 
  constructor(private gestationalWeekService: GestationalWeekService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.gestationalWeekService.getAll().pipe(filter(x => !!x), first()).subscribe(response => this.gestationalWeeks = response);
    this.index = this.gestationalWeekAge - 1;
  }

  next(){
    this.index++;
    if(this.index === 42){
      this.index = 0;
    }
  }

  prev(){
    this.index--;
    if(this.index === -1){
      this.index = 41;
    }
  }

  openDialog(title: string, pictureUrl: string, content: string){
    let advicesSplitted: string[] = [];

    if(title === 'СЪВЕТИ'){
      advicesSplitted = content.split(';');
    }
   
    const config = new MatDialogConfig();
    config.data = {
      title: title,
      pictureUrl: pictureUrl,
      content: title === 'СЪВЕТИ' ? advicesSplitted : [content]
    }

    this.dialog.open(AdditionalInfoDialogComponent, config);
  }
}
