import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Event } from '../models/event';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.scss']
})
export class EditEventComponent implements OnInit {


  CurrentEvent: Event = {
    idEvent: 0,
    eventName: "uikutu",
    idVenue: 1,
    description: "helooo",
    idBusinessAccount: 1,
    startHour: "00:12",
    endHour :"14:11",
    startDate: "0012-12-12",
    endDate: "0003-12-12",
    idCategory: 1
  };

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  editEventForm = new FormGroup({
    idEvent: new FormControl(),
    eventName: new FormControl(),
    idVenue:new FormControl(),
    description: new FormControl(),
    idBusinessAccount: new FormControl(),
    startHour: new FormControl(),
    endHour: new FormControl(),
    startDate: new FormControl(),
    endDate: new FormControl(),
    idCategory: new FormControl(),


  });

  editEvent(eventt:any) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/Event/edit-event`,eventt, {
      observe: 'response',
    }
    );
  }

  FinalizeEdit() {
    let eventToEdit: Event = {
      idEvent:this.editEventForm.get('idEvent')?.value,
      eventName: this.editEventForm.get('eventName')?.value,
      idVenue: 1,
      description: this.editEventForm.get('description')?.value,
      idBusinessAccount: 1,
      startHour: this.editEventForm.get('startHour')?.value,
      endHour: this.editEventForm.get('endHour')?.value,
      startDate: this.editEventForm.get('startDate')?.value,
      endDate: this.editEventForm.get('endDate')?.value,
      idCategory: 1,
    }
    this.editEvent(eventToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}
