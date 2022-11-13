import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as sidenavConstants from '../../shared/constants/sidenav.constants';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  sidenavConstants = sidenavConstants;
  userId = sessionStorage.getItem('userId');

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToProfilePage(){
    this.router.navigate(['/user', this.userId, 'profile']);
  }

  navigateToContactUsPage(){
    this.router.navigate(['/user', this.userId, 'contact-us']);
  }

  navigateToMyTasksPage(){
    this.router.navigate(['/user', this.userId, 'my-tasks']);
  }
}
