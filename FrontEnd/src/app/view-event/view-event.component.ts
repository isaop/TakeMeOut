import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-event',
  templateUrl: './view-event.component.html',
  styleUrls: ['./view-event.component.scss']
})
export class ViewEventComponent implements OnInit {

  constructor( private http: HttpClient) { }
  thing:any;
  ngOnInit(): void {
    let currentId = Number(localStorage.getItem('currentEventId'));
    this.getEventById(currentId).subscribe((response) => {
      this.thing = response;
      console.log(this.thing);
    });

  }

  getEventById(id:number) {
    console.log("aici");
    return this.http.get<any[]>(`${environment.BaseUrl}/Event/get-event-by-id`, {
    });
  }



}
