import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignUpPageComponent } from './sign-up-page/sign-up-page.component';

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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
