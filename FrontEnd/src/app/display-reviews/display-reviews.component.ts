import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-display-reviews',
  templateUrl: './display-reviews.component.html',
  styleUrls: ['./display-reviews.component.scss']
})
export class DisplayReviewsComponent implements OnInit {

  constructor(
    private http: HttpClient,
    private _router: Router,
      // public eventService: EventService,
     ) { }

    name:any;
    events:any;
    ngOnInit(): void {

   }



  goToCardInfo(id:number){
    console.log(id);
    localStorage.setItem('currentEventId', JSON.stringify(id));
    this._router.navigate(['view-event']);
  }







}
