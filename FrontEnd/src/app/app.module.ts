import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { DisplayEventsComponent } from './display-events/display-events.component';
import { UserPageComponent } from './user-page/user-page.component';
import { VenueViewComponent } from './venue-view/venue-view.component';
import { VenueEditComponent } from './venue-edit/venue-edit.component';
import { BaViewComponent } from './ba-view/ba-view.component';
import { BaEditComponent } from './ba-edit/ba-edit.component';
import { BaChangePasswdComponent } from './ba-change-passwd/ba-change-passwd.component';

import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { FormsModule } from '@angular/forms';
import { ReviewComponent } from './review/review.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SuccessPageComponent } from './success-page/success-page.component';
import { EditEventComponent } from './edit-event/edit-event.component';
import { SignupBaComponent } from './signup-ba/signup-ba.component';
import { ViewEventComponent } from './view-event/view-event.component';
import { ChooseAccountComponent } from './choose-account/choose-account.component';
import { Success1Component } from './success1/success1.component';
import { UserEditComponent } from './user-edit/user-edit.component';
import { DisplayReviewsComponent } from './display-reviews/display-reviews.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    SignUpPageComponent,
    UserPageComponent,
    CreateEventComponent,
    DisplayEventsComponent,
    VenueViewComponent,
    VenueEditComponent,
    ForgotPasswordComponent,
    ReviewComponent,
    BaViewComponent,
    BaEditComponent,
    BaChangePasswdComponent,
    SuccessPageComponent,
    EditEventComponent,
    SignupBaComponent,
    ViewEventComponent,
    ChooseAccountComponent,
    Success1Component,
    UserEditComponent,
    DisplayReviewsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
