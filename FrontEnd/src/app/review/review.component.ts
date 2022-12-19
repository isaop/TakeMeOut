import { Component, OnInit } from '@angular/core';
import { EventEdit } from '../models/event'

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
  event: EventEdit = {
    name: 'Event name',
    description: 'quick yoga cred'
  };
  constructor() { }

  ngOnInit(): void {
  }

  PublishReview(){
    //
  }
}
