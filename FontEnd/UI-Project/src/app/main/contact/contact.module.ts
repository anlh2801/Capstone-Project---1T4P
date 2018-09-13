import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, Router, RouterModule } from '@angular/router';
import { ContactComponent } from './contact.component';
import { DataService } from '../../core/services/data.service';
import { NotificationService } from '../../core/services/notification.service';

const roleRoutes: Routes = [
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  //localhost:4200/main/home/index
  { path: 'index', component: ContactComponent }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(roleRoutes)
  ],
  declarations: [ContactComponent],
  providers:[DataService,NotificationService]
})
export class ContactModule { }
