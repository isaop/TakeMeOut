import { Component, OnInit } from '@angular/core';
//import $ from "jquery";

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
export class CreateEventComponent implements OnInit {

  // animating: any;
  // current_fs: any;
  // previous_fs: any;
  // next_fs: any;


  constructor() { }

  ngOnInit(): void {
  }

//   SubmitClick() {}


// PreviousClick() {
//   if(this.animating) return false;
//   this.animating = true;

//   this.current_fs = $(this).parent();
//   this.previous_fs = $(this).parent().prev();

//   //de-activate current step on progressbar
//   $("#progressbar li").eq($("fieldset").index(this.current_fs)).removeClass("active");

//   //show the previous fieldset
//   this.previous_fs.show();
//   //hide the current fieldset with style
//   this.current_fs.animate({opacity: 0}, {
//     step: function(now: number, mx: any) {
//       //as the opacity of current_fs reduces to 0 - stored in "now"
//       //1. scale previous_fs from 80% to 100%
//       var scale = 0.8 + (1 - now) * 0.2;
//       //2. take current_fs to the right(50%) - from 0%
//       var left = ((1-now) * 50)+"%";
//       //3. increase opacity of previous_fs to 1 as it moves in
//       var opacity = 1 - now;
//       this.current_fs.scss({'left': left});
//       this.previous_fs.scss({'transform': 'scale('+scale+')', 'opacity': opacity});
//     },
//     duration: 800,
//     complete: function(){
//       this.current_fs.hide();
//       this.animating = false;
//     },
//     //this comes from the custom easing plugin
//     easing: 'easeInOutBack'
//   });
// }



// NextClick(){
//   if(this.animating) return false;
//   this.animating = true;

//   this.current_fs = $(this).parent();
//   this.next_fs = $(this).parent().next();

//   //activate next step on progressbar using the index of next_fs
//   $("#progressbar li").eq($("fieldset").index(this.next_fs)).addClass("active"),

//   //show the next fieldset
//   this.next_fs.show(),
//   //hide the current fieldset with style
//   this.current_fs.animate({opacity: 0}, {
//     step: function(now: number, mx: any) {
//       //as the opacity of current_fs reduces to 0 - stored in "now"
//       //1. scale current_fs down to 80%
//       var scale = 1 - (1 - now) * 0.2;
//       //2. bring next_fs from the right(50%)
//       var left = (now * 50)+"%";
//       //3. increase opacity of next_fs to 1 as it moves in
//       var opacity = 1 - now;
//       this.current_fs.css({
//         'transform': 'scale('+scale+')',
//         'position': 'absolute'
//       });
//       this.next_fs.scss({'left': left, 'opacity': opacity});
//     },
//     duration: 800,
//     complete: function(){
//       this.current_fs.hide();
//       this.animating = false;
//     },
//     //this comes from the custom easing plugin
//     easing: 'easeInOutBack'
//   });
// }

}



