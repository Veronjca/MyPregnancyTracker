import { Component, OnInit } from '@angular/core';
import * as postRegisterPageConstants from '../shared/post-register-page.constants';

@Component({
  selector: 'app-post-register-page',
  templateUrl: './post-register-page.component.html',
  styleUrls: ['./post-register-page.component.scss']
})
export class PostRegisterPageComponent implements OnInit {
  postRegisterPageConstants = postRegisterPageConstants;

  constructor() { }

  ngOnInit(): void {
  }

}
