import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, OnInit } from '@angular/core';
import { ElementRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { UserEdit } from '../models/userEdit';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {

  @ViewChild('textToEdit') textToEdit!: ElementRef;
  editing = false;
  ChangePass = false;
  ContentPass = false;
  inputText = '';
  inputPassword = '';
  inputPasswordVerification = '';
  successfullyReset = false;
  checkPassword = false;
  WrongPassword = false;
  OpenEditForm = false;

  initialText: User = {
    userId: 0,
    name: 'John',
    surname: 'Doe',
    email: 'john.doe@example.com',
    phoneNumber: '1234567890',
    password: 'secret'
  };

  editUser(userToEdit: UserEdit) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/User/edit-user`, {
      observe: 'response',
      responseType: 'text',
    }
    );
  }

  constructor(private router: Router, private http: HttpClient) {

  }

  signUpFormEdit = new FormGroup({
    nameEdit: new FormControl(),
    surnameEdit: new FormControl(),
    emailEdit: new FormControl(),
    phoneNumberEdit: new FormControl(),
  });

  FinalizeEdit() {
    let userToEdit: UserEdit = {
      userId: 0,
      name: this.signUpFormEdit.get('nameEdit')?.value,
      surname: this.signUpFormEdit.get('surnameEdit')?.value,
      email: this.signUpFormEdit.get('emailEdit')?.value,
      phoneNumber: this.signUpFormEdit.get('phoneNumberEdit')?.value,
    }
    this.editUser(userToEdit).subscribe((response) => {
      console.log(response);
    })
  }






















  ngOnInit(): void {
  }

  saveText() {
    this.initialText = this.textToEdit.nativeElement.innerText;
    this.editing = false;
  }

  cancelEdit() {
    this.textToEdit.nativeElement.innerText = this.initialText;
    this.editing = false;
  }

  CheckInputText(user: User) {
    //for checking if inputted password is the same as the one from the DB.
    //but this is kinda a backend function :(
    if (this.inputText === user.password) {
      console.log("true");
      this.ContentPass = true;
      this.checkPassword = false;
      this.WrongPassword = false;
    } else {
      console.log("false");
      this.WrongPassword = true;
    }
  }
  ResetPassword() {
    if (this.inputPassword === this.inputPasswordVerification) {
      console.log("true");
      this.ChangePass = false;
      this.successfullyReset = true;
      //succesfully entered new password
      //but this is kinda a backend function :(
    } else {
      console.log("false");
      this.WrongPassword = true;
    }
  }
}
