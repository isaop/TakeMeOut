import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-display-events',
  templateUrl: './display-events.component.html',
  styleUrls: ['./display-events.component.scss']
})
export class DisplayEventsComponent implements OnInit {

    constructor(
    private http: HttpClient
      // public eventService: EventService,
     ) { }

    name:any;
    events:any;
    ngOnInit(): void {
    this.getListEvents().subscribe((response) => {
      localStorage.setItem('events', JSON.stringify(response));
      this.name = response.at(0);
    });
    this.events = localStorage.getItem('events');
    // console.log(this.events);
    console.log(this.name);
    var arrayOfEvents = JSON.parse(this.events);
    console.log(arrayOfEvents);
    this.events = arrayOfEvents;
   }

   getListEvents() {
    return this.http.get<Event[]>(`${environment.BaseUrl}/get-all-events`, {
    });
  }






}
