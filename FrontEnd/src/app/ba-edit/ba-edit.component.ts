import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { BusinessAccountEdit } from '../models/ba';

@Component({
  selector: 'app-ba-edit',
  templateUrl: './ba-edit.component.html',
  styleUrls: ['./ba-edit.component.scss']
})
export class BaEditComponent implements OnInit {
  
  BA: BusinessAccountEdit = {
    userId: '21',
    name: 'John Ioan',
    venueName: 'La tevi',
    phoneNumber: '0273333333',
    address: 'acasa',
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
      userId: "21",
      name: this.BAFormEdit.get('nameEdit')?.value,
      venueName: this.BAFormEdit.get('venueNameEdit')?.value,
      phoneNumber: this.BAFormEdit.get('addressEdit')?.value,
      address: this.BAFormEdit.get('phoneNumberEdit')?.value,
      description: this.BAFormEdit.get('descriptionEdit')?.value,
    }
    this.editUser(BA_ToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}
