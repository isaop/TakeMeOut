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
import { VenueViewComponent, VenueViewComponent } from './venue-view/venue-view.component';
import { VenueEditComponent } from './venue-edit/venue-edit.component';
import { BaViewComponent } from './ba-view/ba-view.component';
import { BaEditComponent } from './ba-edit/ba-edit.component';
import { BaChangePasswdComponent } from './ba-change-passwd/ba-change-passwd.component';

import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { FormsModule } from '@angular/forms';
import { ReviewComponent } from './review/review.component';
import { ReactiveFormsModule } from '@angular/forms';

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
    BaChangePasswdComponent
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
