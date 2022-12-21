import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Venue } from '../models/venue';

@Component({
  selector: 'app-venue-view',
  templateUrl: './venue-view.component.html',
  styleUrls: ['./venue-view.component.scss']
})
export class VenueViewComponent implements OnInit {

  constructor(private http: HttpClient) { }

  venues: any;

  ngOnInit(): void {
    this.getListVenues().subscribe((response) =>{
     localStorage.setItem('venues', JSON.stringify(response));
    });

    this.venues = localStorage.getItem('venues');
    var arrOfVenues = JSON.parse(this.venues);
    console.log(arrOfVenues);
    this.venues = arrOfVenues;
  }

  getListVenues() {
    return this.http.get<Venue[]>(`${environment.BaseUrl}/get-all-venues`, {
    });
  }
}
