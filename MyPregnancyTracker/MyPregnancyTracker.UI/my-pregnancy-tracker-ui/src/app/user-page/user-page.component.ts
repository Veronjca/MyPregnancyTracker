import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { filter, first } from 'rxjs';
import { AccountsService } from '../services/accounts.service';
import { UserService } from '../services/user.service';
import * as userPageConstants from '../shared/constants/user-page.constants';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  userPageConstants = userPageConstants;
  userName: string = sessionStorage.getItem('userName')!;
  userId: string = sessionStorage.getItem('userId')!;

  constructor(private accountService: AccountsService,
    private router: Router,
    private userService: UserService) { }

  ngOnInit(): void {
    this.userService.setGestationalWeek(this.userId).pipe(first()).subscribe();
  }

  logout(): void{
    this.accountService.logout();
    this.router.navigate(['/']);
  }
}

