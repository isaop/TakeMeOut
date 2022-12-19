import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEventComponent } from './create-event/create-event.component';
import { DisplayEventsComponent } from './display-events/display-events.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { VenueViewComponent } from './venue-view/venue-view.component';
import { VenueEditComponent } from './venue-edit/venue-edit.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ReviewComponent } from './review/review.component';
import { BaViewComponent } from './ba-view/ba-view.component';
import { BaEditComponent } from './ba-edit/ba-edit.component';
import { BaChangePasswdComponent } from './ba-change-passwd/ba-change-passwd.component';
import { SuccessPageComponent } from './success-page/success-page.component';
import { SignupBaComponent } from './signup-ba/signup-ba.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'login-page',
    component: LoginPageComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'sign-up-page',
    component: SignUpPageComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'create-event',
    component: CreateEventComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'display-events',
    component: DisplayEventsComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'user-page',
    component: UserPageComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'venue-view',
    component: VenueViewComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'venue-edit',
    component: VenueEditComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'ba-view',
    component: BaViewComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'ba-edit',
    component: BaEditComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'ba-change-passwd',
    component: BaChangePasswdComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'forgot-password',
    component: ForgotPasswordComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'review',
    component: ReviewComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'success',
    component: SuccessPageComponent,
    title: 'TakeMeOut',
  },
  {
    path: 'signup-ba',
    component: SignupBaComponent,
    title: 'TakeMeOut',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
