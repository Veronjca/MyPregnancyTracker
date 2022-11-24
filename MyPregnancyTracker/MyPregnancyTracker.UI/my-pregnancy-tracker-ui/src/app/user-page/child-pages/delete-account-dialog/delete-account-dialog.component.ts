import { DialogRef } from '@angular/cdk/dialog';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AccountsService } from 'src/app/services/accounts.service';
import * as dialogConstants from '../../../shared/constants/dialog.constants';

@Component({
  selector: 'app-delete-account-dialog',
  templateUrl: './delete-account-dialog.component.html',
  styleUrls: ['./delete-account-dialog.component.scss']
})
export class DeleteAccountDialogComponent implements OnInit {
  userId = sessionStorage.getItem('userId');
  dialogConstants = dialogConstants;

  constructor(private dialogRef: DialogRef<DeleteAccountDialogComponent>,
    private accountService: AccountsService,
    private router: Router) { }

  ngOnInit(): void {
  }

  onCancel(){
    this.dialogRef.close();
  }

  onSubmit(){
      this.accountService.deleteAccount(this.userId!).pipe(first()).subscribe();  
      this.accountService.logout();
      this.dialogRef.close();
      this.router.navigate(['/']);        
  }
}
