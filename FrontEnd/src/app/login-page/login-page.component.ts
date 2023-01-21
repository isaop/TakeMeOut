import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { LogIn } from '../models/LogIn';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  email = new FormControl('');
  password = new FormControl('');

  constructor(private router: Router, private http: HttpClient) {}

  ngOnInit(): void {}

  LogInForm = new FormGroup({
    email: new FormControl(),
    password: new FormControl(),
  });

  LoginUser() {
    let LogIn: LogIn = {
      email: this.LogInForm.get("email")?.value,
      password: this.LogInForm.get("password")?.value
    }
    this.SignUser(LogIn).subscribe((response) => {
      if (response.statusText == "OK" && response.body) {
        this.router.navigate(['success']);
      }
    });
  }
  LoginUserBA() {
    let LogIn: LogIn = {
      email: this.LogInForm.get("email")?.value,
      password: this.LogInForm.get("password")?.value
    }
    this.SignBA(LogIn).subscribe((response) => {
      if (response.statusText == "OK" && response.body) {
        this.router.navigate(['success']);
      }
    });
  }
  SignupUser() {
    this.router.navigate(['choose-account']);
  }
  SignUser(User: any) {
    return this.http.post(`${environment.BaseUrl}/LoginUser/login`, User, {
      observe: 'response',
      responseType: 'text',
    });
  }
  SignBA(User: any) {
    return this.http.post(`${environment.BaseUrl}/LoginBA/login`, User, {
      observe: 'response',
      responseType: 'text',
    });
  }
}