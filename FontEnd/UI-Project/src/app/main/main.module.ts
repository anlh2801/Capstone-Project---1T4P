import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { mainRoutes } from './main.routes';
import { RouterModule, Routes } from '@angular/router';
import { HomeModule } from './home/home.module';
import {UtilityService} from '../core/services/utility.service';
import {AuthenService} from '../core/services/authen.service';
import { ContactComponent } from './contact/contact.component';
import { ContactModule } from './contact/contact.module';

@NgModule({
  imports: [
    CommonModule,
    HomeModule,
    RouterModule.forChild(mainRoutes)
  ],
  declarations: [MainComponent],
  providers:[UtilityService,AuthenService]
})
export class MainModule { }
