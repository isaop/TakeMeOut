import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss']
})
export class SignUpPageComponent implements OnInit {

  name=new FormControl('');
  surname=new FormControl('');
  phone=new FormControl('');
  password=new FormControl('');
  email=new FormControl('');
  address=new FormControl('');
  city=new FormControl('');
  country=new FormControl('');

  constructor(

    private router: Router,
    private http: HttpClient
    ) { }

  ngOnInit(): void {
  }

  signUpForm = new FormGroup({
    name: new FormControl(),
    surname: new FormControl(),
    email: new FormControl(),
    phoneNumber: new FormControl(),
    password: new FormControl(),
  });

  Register(){
    let user: User = {
      userId: 0,
      name: this.signUpForm.get('name')?.value,
      surname: this.signUpForm.get('surname')?.value,
      email: this.signUpForm.get('email')?.value,
      phoneNumber: this.signUpForm.get('phoneNumber')?.value,
      password: this.signUpForm.get('password')?.value,
    }

    console.log(user.name);

    this.addUser(user).subscribe((response) => {
      console.log(response);
      if(response.statusText == "OK")
          this.router.navigate(['success1']);
    });
  }

  addUser(user: any) {
    return this.http.post(`${environment.BaseUrl}/SignUp/sign-up-user`, user, {
      observe: 'response',
      responseType: 'text',
    });
  }
}
