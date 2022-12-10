import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as dialogConstants from '../../../shared/constants/dialog.constants';

@Component({
  selector: 'app-additional-info-dialog',
  templateUrl: './additional-info-dialog.component.html',
  styleUrls: ['./additional-info-dialog.component.scss']
})
export class AdditionalInfoDialogComponent implements OnInit {
  dialogConstants = dialogConstants;
  title: string = '';
  content: string[] = [];
  pictureUrl: string = '';

  constructor(@Inject(MAT_DIALOG_DATA) config: any,
   private dialogRef: MatDialogRef<AdditionalInfoDialogComponent>) { 
    this.content = config.content;
    this.title = config.title;
    this.pictureUrl = config.pictureUrl;
  }

  ngOnInit(): void {
  }

  onClose(): void{
    this.dialogRef.close();
  }
}
