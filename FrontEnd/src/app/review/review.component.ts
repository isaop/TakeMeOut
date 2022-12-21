import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Event } from '../models/event'
import { Review } from '../models/review';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {

  score = new FormControl('');
  description = new FormControl('');

  event: Event = {
    idEvent: 16,
    eventName: "InterestingEvent",
    idVenue: 1,
    description: "descrrrr",
    idBusinessAccount: 1,
    startHour: "00:12",
    endHour: "14:11",
    startDate: "0012-12-12",
    endDate: "0003-12-12",
    idCategory: 1
  };

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
  }

  reviewForm = new FormGroup({
    comment: new FormControl(),
  })

  PublishReview(){
    let review : Review = {
      idReview: 0,
      idEvent: 1,
      idUser: 3,
      idPayment: 1,
      comment: this.reviewForm.get('comment')?.value,
    }

    this.addReview(review).subscribe((response) => {
      console.log(response);

          this.router.navigate(['success']);
    });
  }

  addReview(review: any){
    return this.http.post(`${environment.BaseUrl}/Review/add-review`, review, {
      observe: 'response',
      responseType: 'text',
    });
  }
}
