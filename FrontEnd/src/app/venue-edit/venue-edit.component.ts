import { Component, OnInit } from '@angular/core';
import { VenueEdit } from '../models/venueEdit';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-venue-edit',
  templateUrl: './venue-edit.component.html',
  styleUrls: ['./venue-edit.component.scss']
})
export class VenueEditComponent implements OnInit {

  VenueInfo: VenueEdit={
    name: "Venue Name",
    description: "Venue Description",
    contactNumber: "Venue contact Number",
    address: "Venue Address",
  }

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  editVenue(venuToEdit: VenueEdit) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/edit-venue`, {
      observe: 'response',
      responseType: 'text',
    }
    );
  }
  VenueFormEdit = new FormGroup({
    nameEdit: new FormControl(),
    descriptionEdit: new FormControl(),
    addressEdit: new FormControl(),
    phoneNumberEdit: new FormControl(),
  });

  FinalizeEdit() {
    let userToEdit: VenueEdit = {
      name: this.VenueFormEdit.get('nameEdit')?.value,
      description: this.VenueFormEdit.get('descriptionEdit')?.value,
      contactNumber: this.VenueFormEdit.get('phoneNumberEdit')?.value,
      address: this.VenueFormEdit.get('addressEdit')?.value,
    }
    this.editVenue(userToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}
