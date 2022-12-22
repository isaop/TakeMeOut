import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { BA } from '../models/ba';


@Component({
  selector: 'app-signup-ba',
  templateUrl: './signup-ba.component.html',
  styleUrls: ['./signup-ba.component.scss']
})
export class SignupBaComponent implements OnInit {

  constructor(
    private router: Router,
    private http: HttpClient
    ) { }

  ngOnInit(): void {
  }

  signUpForm = new FormGroup({
    name: new FormControl(),
    description: new FormControl(),
    email: new FormControl(),
    contactNumber: new FormControl(),
    password: new FormControl(),
  });

  Register(){
    let ba: BA = {
      BAId: 0,
      name: this.signUpForm.get('name')?.value,
      password: this.signUpForm.get('password')?.value,
      description: this.signUpForm.get('description')?.value,
      email: this.signUpForm.get('email')?.value,
      contactNumber: this.signUpForm.get('contactNumber')?.value,
      VenueID: 1,
    }


      this.addBA(ba).subscribe((response) => {
        console.log(response);
        if(response.statusText == "OK")
            this.router.navigate(['success']);
      });
  }

      addBA(ba: any) {
        return this.http.post(`${environment.BaseUrl}/SignUp/sign-up-business-account`, ba, {
          observe: 'response',
          responseType: 'text',
        });

      }

}
