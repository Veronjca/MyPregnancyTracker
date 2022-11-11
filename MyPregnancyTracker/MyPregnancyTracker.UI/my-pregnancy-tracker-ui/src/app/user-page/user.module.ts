import { CommonModule } from "@angular/common";
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { RouterModule } from "@angular/router";

import { MatCardModule } from "@angular/material/card";
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';

import { PaginatorComponent } from "./paginator/paginator.component";
import { DashboardPageComponent } from "./child-pages/dashboard-page/dashboard-page.component";
import { UserPageComponent } from "./user-page.component";
import { SidenavComponent } from "./sidenav/sidenav.component";
import { ProfilePageComponent } from './child-pages/profile-page/profile-page.component';

@NgModule({
    declarations: [ 
        UserPageComponent,   
        PaginatorComponent,   
        DashboardPageComponent,
        SidenavComponent,
        ProfilePageComponent,
    ], 
    imports: [
        CommonModule, 
        RouterModule.forChild([{
            path:'', 
            children:[
                {path: '', component: DashboardPageComponent},
                {path:'profile', component: ProfilePageComponent}
            ]
        }]),
        MatCardModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatTooltipModule,
        MatToolbarModule,
        MatSidenavModule
    ], 
    schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class UserModule{}