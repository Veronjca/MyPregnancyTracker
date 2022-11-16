import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { filter, first } from 'rxjs';
import { UpdateUserProfileRequest } from 'src/app/models/update-user-profile-request.model';
import { AccountsService } from 'src/app/services/accounts.service';
import * as profilePageConstants from '../../../shared/constants/profile-page.constants';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {
  userEmail = sessionStorage.getItem("email"); 
  profilePageConstants = profilePageConstants;
  updateUserProfileRequest!: UpdateUserProfileRequest;
  userId = '';
  step = 0;

  profileForm = new FormGroup({
    firstName: new FormControl('',),
    lastName: new FormControl('',),
    height: new FormControl('', Validators.pattern("^[0-9]*$")),
    weight: new FormControl('', Validators.pattern("^[0-9]*$")),
    birthDate: new FormControl(''),
    dueDate: new FormControl('')
  })
  constructor(private accountService: AccountsService) { 
    this.userId = sessionStorage.getItem('userId')!;
  }

  ngOnInit(): void {
    this.accountService.getUserProfileData().pipe(filter(x => !!x), first()).subscribe(response => {
      this.profileForm.setValue({
        firstName: response.firstName,
        lastName: response.lastName,
        height: response.height.toString(),
        weight: response.weight.toString(),
        birthDate: response.birthDate,
        dueDate: response.dueDate
      });
    })
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  updateUserProfile(){
    this.updateUserProfileRequest = {
      userId: this.userId,
      firstName: this.profileForm.value.firstName!,
      lastName: this.profileForm.value.lastName!,
      birthDate: this.profileForm.value.birthDate!,
      height: Number(this.profileForm.value.height!),
      weight: Number(this.profileForm.value.weight!),
      dueDate: this.profileForm.value.dueDate!
    }

    this.accountService.updateUserProfile(this.updateUserProfileRequest).subscribe();
  }
}
