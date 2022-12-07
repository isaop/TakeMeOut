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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
