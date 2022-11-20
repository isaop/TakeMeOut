import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

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
  venue=new FormControl('');
  email=new FormControl('');
  address=new FormControl('');
  city=new FormControl('');
  country=new FormControl('');
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
