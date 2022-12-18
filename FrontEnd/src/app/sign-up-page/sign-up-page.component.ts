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
  email=new FormControl('');
  address=new FormControl('');
  city=new FormControl('');
  country=new FormControl('');

  constructor() { }

  ngOnInit(): void {
  }

  Register(){
    console.log("you are registered!")
  }
}
