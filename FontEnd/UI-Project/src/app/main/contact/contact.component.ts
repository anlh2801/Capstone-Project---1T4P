import { Component, OnInit } from '@angular/core';
import { DataService } from '../../core/services/data.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  public contacts :any = [];
  constructor( private _dataService: DataService) { 
    this.loadAllContact();
  }

  ngOnInit() {
  }
  public loadAllContact () {
      this._dataService.get('/contact/all-contact').subscribe((res: any)=>{
        this.contacts = res;
      });
  }
}
