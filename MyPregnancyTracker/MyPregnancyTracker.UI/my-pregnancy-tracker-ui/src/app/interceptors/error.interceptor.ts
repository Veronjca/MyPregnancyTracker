import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../error-dialog/error-dialog.component';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router,
    private matDialog: MatDialog) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request)
    .pipe(catchError((errorResponse: HttpErrorResponse) => {   
      if(errorResponse.error) {
        let error = errorResponse.error.pop();

        if(error.code == "DuplicateUserName" || error.code == "DuplicateEmail" ){
          this.matDialog.open(ErrorDialogComponent);
        }
       
        return throwError(() => errorResponse.message);
      } 

      this.router.navigate(["/error"]);
      return throwError(() => errorResponse.message);
    }));
  }
}
