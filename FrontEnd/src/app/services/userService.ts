import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export class UserService{


  constructor(private http: HttpClient){}

  addUser(user: any) {
    return this.http.post(`${environment.BaseUrl}/SignUp/sign-up-user`, user, {
      observe: 'response',
      responseType: 'text',
    });
  }
}
