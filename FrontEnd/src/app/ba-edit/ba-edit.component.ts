import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { BusinessAccountEdit } from '../models/business-account-edit';

@Component({
  selector: 'app-ba-edit',
  templateUrl: './ba-edit.component.html',
  styleUrls: ['./ba-edit.component.scss']
})
export class BaEditComponent implements OnInit {

  businessAccount: BusinessAccountEdit = {
    idBusinessAccount: 0,
    name: "Nume",
    description: "Descr",
    email: "mail",
    contactNumber: "contact",
    idVenue: 1
  };

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  editBusinessAccountForm = new FormGroup({
    name: new FormControl(),
    idVenue: new FormControl(),
    contactNumber: new FormControl(),
    email: new FormControl(),
    description: new FormControl(),
  });

  editBusinessAccount(BA_ToEdit: BusinessAccountEdit) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/BusinessAccount/edit-business-account`, BA_ToEdit, {
      observe: 'response',
    }
    );

  }

  FinalizeEdit() {
    let BA_ToEdit: BusinessAccountEdit = {
      idBusinessAccount: 1,
      name: this.editBusinessAccountForm.get('name')?.value,
      description: this.editBusinessAccountForm.get('description')?.value,
      email: this.editBusinessAccountForm.get('email')?.value,
      contactNumber: this.editBusinessAccountForm.get('contactNumber')?.value,
      idVenue: 1
    }
    console.log(BA_ToEdit);
    this.editBusinessAccount(BA_ToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}
