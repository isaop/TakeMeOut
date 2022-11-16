import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.scss']
})
export class SignUpPageComponent implements OnInit {

  name:string | undefined;
  surname:string | undefined;
  phone:number|undefined;
  password:string | undefined;
  venue:string | undefined;
  email:string | undefined;
  address:string | undefined;
  city:string | undefined;
  country:string | undefined;
  displayU=false;
  displayB=false;


  constructor() { }

  ngOnInit(): void {
  }

  User(){
    this.displayU=true;
  }
  BusinessUser(){
    this.displayB=true;
  }
  Register(){
    console.log("you are registered!")
  }
}
