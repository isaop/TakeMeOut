import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Venue } from '../models/venue';

export class VenueService{

  constructor(private http: HttpClient){}

  getListVenues() {
    return this.http.get<Venue[]>(`${environment.BaseUrl}/get-all-venues`, {
    });
  }
}