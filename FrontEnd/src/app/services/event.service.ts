import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export class EventService{


  constructor(private http: HttpClient){}

  getListEvents() {
    return this.http.get<Event[]>(`${environment.BaseUrl}/get-all-events`, {
    });
  }
}
