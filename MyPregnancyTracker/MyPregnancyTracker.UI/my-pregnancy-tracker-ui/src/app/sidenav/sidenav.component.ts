import { Component, OnInit } from '@angular/core';
import * as sidenavConstants from '../shared/constants/sidenav.constants';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  sidenavConstants = sidenavConstants;

  constructor() { }

  ngOnInit(): void {
  }

}
