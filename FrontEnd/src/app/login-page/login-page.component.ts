import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  usernameInput= new FormControl('');
  passwordInput= new FormControl('');
  display=false;
  username=new FormControl('');
  password=new FormControl('');

  constructor() { }

  ngOnInit(): void {
  }

  LoginUser(){
    //backend job
  }
  SignupUser(){
    //backend job
  }

}
