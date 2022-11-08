import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountsService } from '../services/accounts.service';
import * as userPageConstants from '../shared/constants/user-page.constants';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  userName: string = sessionStorage.getItem('userName')!;
  userId: string = '';
  userPageConstants = userPageConstants;

  constructor(private accountService: AccountsService,
    private router: Router) { }

  ngOnInit(): void {
    this.userId = this.router.url.replace('/user/', '');
  }

  logout(): void{
    this.accountService.logout();
    this.router.navigate(['/']);
  }
}
