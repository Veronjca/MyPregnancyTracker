import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogConfig, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as dialogConstants from '../../../shared/constants/dialog.constants';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
  dialogConstants = dialogConstants;
  title: string = '';
  content: string[] = [];
  pictureUrl: string = '';

  constructor(@Inject(MAT_DIALOG_DATA) config: any,
   private dialogRef: MatDialogRef<DialogComponent>) { 
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
