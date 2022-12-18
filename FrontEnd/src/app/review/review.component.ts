import { Component, OnInit } from '@angular/core';
import { Event } from '../models/event'

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
  event: Event = {
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
