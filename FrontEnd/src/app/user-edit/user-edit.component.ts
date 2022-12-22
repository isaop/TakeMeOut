import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { UserEdit } from '../models/userEdit';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  user: UserEdit = {
    idUser: 6,
    name: 'After',
    surname: 'business accuont interesant',
    email: 'business_account@yahoo.com',
    phoneNumber: '0273333333',
  };



  editUserForm = new FormGroup({
    idUser: new FormControl(),
    name: new FormControl(),
    surname: new FormControl(),
    email: new FormControl(),
    phoneNumber: new FormControl(),
  });

  editUser(userToEdit: UserEdit) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/User/edit-user`, userToEdit , {
      observe: 'response',
    }
    );
  }

  FinalizeEdit() {
    let userToEdit: UserEdit = {
      idUser: 3,
      name: this.editUserForm.get('name')?.value,
      surname:  this.editUserForm.get('surname')?.value,
      email: this.editUserForm.get('email')?.value,
      phoneNumber: this.editUserForm.get('phoneNumber')?.value,
    }
    this.editUser(userToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}

