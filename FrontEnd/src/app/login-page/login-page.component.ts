import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  username:string | undefined;
  password:string | undefined;
  display=false;


  constructor() { }

  ngOnInit(): void {
  }

  LoginUser(){
    if(this.username=="admin" && this.password=="12345"){
      console.log("Signed in!")
    }
  }
  SignupUser(){
    this.display=true;
  }

}
