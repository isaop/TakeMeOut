import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { CreateEvent } from '../models/create-event';
//import $ from "jquery";

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
export class CreateEventComponent implements OnInit {

  name=new FormControl('');
  venue=new FormControl('');
  startDate=new FormControl('');
  endDate=new FormControl('');
  startTime=new FormControl('');
  endTime=new FormControl('');
  category=new FormControl('');
  description=new FormControl('');
  
  constructor(
    private router: Router,
    private http: HttpClient
    ) { }

  ngOnInit(): void {
  }

  createEventForm = new FormGroup({
    name: new FormControl(),
    venue: new FormControl(),
    startDate: new FormControl(),
    endDate: new FormControl(),
    startTime: new FormControl(),
    endTime: new FormControl(),
    category: new FormControl(),
    description: new FormControl(),
  });

  CreateEvent(){
    let event: CreateEvent = {
      eventName: this.createEventForm.get('name')?.value,
      VenueID: 1,
      venue: this.createEventForm.get('venue')?.value,
      startDate: this.createEventForm.get('startDate')?.value,
      endDate: this.createEventForm.get('endDate')?.value,
      startTime: this.createEventForm.get('startTime')?.value,
      endTime: this.createEventForm.get('endTime')?.value,
      description: this.createEventForm.get('description')?.value,
      category: this.createEventForm.get('category')?.value,
    }

    this.createEvent(event).subscribe((response) => {
      console.log(response);
      if(response.statusText == "OK")
          this.router.navigate(['success']);
    });
  }

  createEvent(event: any){
    return this.http.post(`${environment.BaseUrl}/Event/add-event`, event, {
      observe: 'response',
      responseType: 'text',
    });
  }
}



