import { CommonModule } from "@angular/common";
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from "@angular/core";
import {RouterModule} from  '@angular/router'
import { ReactiveFormsModule } from "@angular/forms";
import bg from '@angular/common/locales/bg';
import { registerLocaleData } from '@angular/common';

import { MatCardModule } from "@angular/material/card";
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDialogModule} from '@angular/material/dialog';
import {MatListModule} from '@angular/material/list';

import { PaginatorComponent } from "./paginator/paginator.component";
import { DashboardPageComponent } from "./child-pages/dashboard-page/dashboard-page.component";
import { UserPageComponent } from "./user-page.component";
import { SidenavComponent } from "./sidenav/sidenav.component";
import { ProfilePageComponent } from './child-pages/profile-page/profile-page.component';
import { ContactUsPageComponent } from './child-pages/contact-us-page/contact-us-page.component';
import { MyTasksPageComponent } from './child-pages/my-tasks-page/my-tasks-page.component';
import { DialogComponent } from './child-pages/dialog/dialog.component';

registerLocaleData(bg);
@NgModule({
    declarations: [ 
        UserPageComponent,   
        PaginatorComponent,   
        DashboardPageComponent,
        SidenavComponent,
        ProfilePageComponent,
        ContactUsPageComponent,
        MyTasksPageComponent,
        DialogComponent,
    ], 
    imports: [
        CommonModule, 
        RouterModule.forChild([{
            path:'', 
            children:[
                {path: '', component: DashboardPageComponent},
                {path: 'profile', component: ProfilePageComponent},
                {path: 'contact-us', component: ContactUsPageComponent},
                {path: 'my-tasks', component: MyTasksPageComponent}
            ]
        }]),
        MatCardModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatTooltipModule,
        MatToolbarModule,
        MatSidenavModule,
        MatExpansionModule,
        MatFormFieldModule,
        ReactiveFormsModule,
        MatInputModule,
        MatDatepickerModule,
        MatCheckboxModule,
        MatDialogModule,
        MatListModule
    ], 
    schemas:[CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [],
    providers: [
        {provide: LOCALE_ID, useValue: 'bg'}
    ]
})
export class UserModule{}