import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResendConfirmationEmailRequest } from '../models/resend-confirmation-email.model';
import { AccountsService } from '../services/accounts.service';
import * as postRegisterPageConstants from '../shared/constants/post-register-page.constants';

@Component({
  selector: 'app-post-register-page',
  templateUrl: './post-register-page.component.html',
  styleUrls: ['./post-register-page.component.scss']
})
export class PostRegisterPageComponent implements OnInit {
  email!: string;
  postRegisterPageConstants = postRegisterPageConstants;

  constructor(private route: ActivatedRoute,
    private accountsService: AccountsService,
    private router: Router) {
    this.route.queryParams.subscribe(params => {
      this.email = params['email'];
    })
  }

  resendConfirmationEmailRequest!: ResendConfirmationEmailRequest;

  ngOnInit(): void {
  }

  resendConfirmationEmail(){
    this.resendConfirmationEmailRequest = {
    email: this.email
    }

    this.accountsService.resendConfirmationEmail(this.resendConfirmationEmailRequest)
          .subscribe(response => {
            this.router.navigate(['/login'])
          });

  }
}
