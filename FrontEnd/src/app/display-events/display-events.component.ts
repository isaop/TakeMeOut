import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-display-events',
  templateUrl: './display-events.component.html',
  styleUrls: ['./display-events.component.scss']
})
export class DisplayEventsComponent implements OnInit {

    constructor(
    private http: HttpClient,
    private _router: Router,
      // public eventService: EventService,
     ) { }

    name:any;
    events:any;
    ngOnInit(): void {
      console.log("aici");
    this.getListEvents().subscribe((response) => {
      localStorage.setItem('events', JSON.stringify(response));
      this.name = response.at(0);
    });
    this.events = localStorage.getItem('events');
    // console.log(this.events);
    var arrayOfEvents = JSON.parse(this.events);
    this.events = arrayOfEvents;
   }

   getListEvents() {
    console.log("aici");
    return this.http.get<any[]>(`${environment.BaseUrl}/Event/get-all-events`, {
    });
  }

  goToCardInfo(id:number){
    console.log(id);
    localStorage.setItem('currentEventId', JSON.stringify(id));
    this._router.navigate(['view-event']);
  }






}
