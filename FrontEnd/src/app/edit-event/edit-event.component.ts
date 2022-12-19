import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { EventEdit } from '../models/event';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.scss']
})
export class EditEventComponent implements OnInit {

  
  CurrentEvent: EventEdit = {
    name: 'yoga',
    description: 'yoga in parc'
  };

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  EventFormEdit = new FormGroup({
    nameEDIT: new FormControl(),
    descriptionEDIT: new FormControl(),
  });

  editEvent(EventToEdit: EventEdit) {

    return this.http.put<Boolean>(
      `${environment.BaseUrl}/Event/edit-event`, {
      observe: 'response',
      responseType: 'text',
    }
    );
  }

  FinalizeEdit() {
    let EventToEdit: EventEdit = {
      name: this.EventFormEdit.get('nameEDIT')?.value,
      description: this.EventFormEdit.get('descriptionEDIT')?.value,
    }
    this.editEvent(EventToEdit).subscribe((response) => {
      console.log(response);
    })
  }

}
