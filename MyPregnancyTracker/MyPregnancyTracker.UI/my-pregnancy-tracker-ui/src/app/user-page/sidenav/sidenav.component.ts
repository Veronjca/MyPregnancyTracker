import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import * as sidenavConstants from '../../shared/constants/sidenav.constants';
import { DeleteAccountDialogComponent } from '../child-pages/delete-account-dialog/delete-account-dialog.component';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  sidenavConstants = sidenavConstants;
  userId = sessionStorage.getItem('userId');
  showDeleteAccountButton = false;

  constructor(private router: Router,
    private dialog: MatDialog) { }

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

  openDeleteAccountDialog(){
      this.dialog.open(DeleteAccountDialogComponent);
  }
}
