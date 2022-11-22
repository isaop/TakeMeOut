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

    events:any;
    ngOnInit(): void {
    this.getListEvents().subscribe((response) => {
      localStorage.setItem('events', JSON.stringify(response));
    });
    this.events = localStorage.getItem('events');
    console.log(this.events);


   }

   getListEvents() {
    return this.http.get<Event[]>(`${environment.BaseUrl}/get-all-events`, {
    });
  }






}
