import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { ConfirmEmailRequest } from '../models/confirm-email.model';
import { AccountsService } from '../services/accounts.service';
import * as confirmEmailConstans from '../shared/confirm-email.constants';

@Component({
  selector: 'app-confirm-email-page',
  templateUrl: './confirm-email-page.component.html',
  styleUrls: ['./confirm-email-page.component.scss']
})
export class ConfirmEmailPageComponent implements OnInit {
    emailToken: string = '';
    userId: string = '';
    confirmEmailConstants = confirmEmailConstans;

    constructor(
      private route: ActivatedRoute,
      private accountsService: AccountsService,
      private router: Router
    ) { 
    this.route.queryParams.subscribe(params => {
      this.emailToken = params['emailToken'];
      this.userId = params['userId'];
    })
  }

  ngOnInit(): void {
    const requestModel: ConfirmEmailRequest = {
      emailToken: this.emailToken, 
      userId: this.userId
    };

    this.accountsService.confirmEmail(requestModel)
        .subscribe(response => this.router.navigate(['/login']));
  }

}
