import { Component, OnInit } from '@angular/core';
import * as footerConstants from '../shared/constants/footer-constants';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  year: number = new Date().getFullYear();
  footerConstants = footerConstants;

  constructor() { }

  ngOnInit(): void {
  }

}
