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
   name: 'Event name',
    description: 'quick yoga cred'
  };

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
  }

  reviewForm = new FormGroup({
    score: new FormControl(),
    description: new FormControl(),
  })

  PublishReview(){
    let review : Review = {
      score: this.reviewForm.get('score')?.value,
      description: this.reviewForm.get('description')?.value,
    }

    this.addReview(review).subscribe((response) => {
      console.log(response);
      if(response.statusText == "OK")
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
