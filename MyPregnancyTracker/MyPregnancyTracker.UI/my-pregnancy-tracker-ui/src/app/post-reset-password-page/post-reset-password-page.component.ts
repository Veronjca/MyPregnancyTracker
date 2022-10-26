import { Component, OnInit } from '@angular/core';
import * as postResetPasswordPageConstants from '../shared/post-reset-password.constants';

@Component({
  selector: 'app-post-reset-password-page',
  templateUrl: './post-reset-password-page.component.html',
  styleUrls: ['./post-reset-password-page.component.scss']
})
export class PostResetPasswordPageComponent implements OnInit {
  postResetPasswordPageConstants = postResetPasswordPageConstants;
  
  constructor() { }

  ngOnInit(): void {
  }

}
