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
    BAId: 21,
    name: 'John Ioan',
    VenueID: 1,
    contactNumber: '0273333333',
    email: 'acasa',
    description: 'buzunarul lui tata',
  };

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  BAFormEdit = new FormGroup({
    nameEdit: new FormControl(),
    venueNameEdit: new FormControl(),
    addressEdit: new FormControl(),
    phoneNumberEdit: new FormControl(),
    descriptionEdit: new FormControl(),
  });

  editUser(BA_ToEdit: BusinessAccountEdit) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/BusinessAccount/edit-business-account`, {
      observe: 'response',
      responseType: 'text',
    }
    );
  }

  FinalizeEdit() {
    let BA_ToEdit: BusinessAccountEdit = {
      BAId: 21,
      name: this.BAFormEdit.get('nameEdit')?.value,
      VenueID: this.BAFormEdit.get('venueNameEdit')?.value,
      contactNumber: this.BAFormEdit.get('addressEdit')?.value,
      email: this.BAFormEdit.get('phoneNumberEdit')?.value,
      description: this.BAFormEdit.get('descriptionEdit')?.value,
    }
    this.editUser(BA_ToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}
