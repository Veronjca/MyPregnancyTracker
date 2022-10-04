import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as homePageConstants from '../../shared/home-page.constants';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  homePageConstants = homePageConstants;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
}
