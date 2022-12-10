import { Component, OnInit } from '@angular/core';
import * as contactUsPageConstants from '../../../shared/constants/contact-us-page.constants';

@Component({
  selector: 'app-contact-us-page',
  templateUrl: './contact-us-page.component.html',
  styleUrls: ['./contact-us-page.component.scss']
})
export class ContactUsPageComponent implements OnInit {
  contactUsPageConstants = contactUsPageConstants;
  
  constructor() { }

  ngOnInit(): void {
  }

}
