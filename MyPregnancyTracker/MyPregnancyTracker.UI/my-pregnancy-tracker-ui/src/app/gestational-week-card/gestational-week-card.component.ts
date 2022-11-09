import { Component, OnInit } from '@angular/core';
import * as gestationalWeekConstants from '../shared/constants/gestational-week.constants';

@Component({
  selector: 'app-gestational-week-card',
  templateUrl: './gestational-week-card.component.html',
  styleUrls: ['./gestational-week-card.component.scss']
})
export class GestationalWeekCardComponent implements OnInit {
  gestationalWeekConstants = gestationalWeekConstants;
  constructor() { }

  ngOnInit(): void {
  }

}
