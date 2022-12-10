import { Component, OnInit } from '@angular/core';
import * as errorPageConstants from '../shared/constants/error-page.constants';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.scss']
})
export class ErrorPageComponent implements OnInit {
  errorPageConstants = errorPageConstants;
  
  constructor() { }

  ngOnInit(): void {
  }

}
