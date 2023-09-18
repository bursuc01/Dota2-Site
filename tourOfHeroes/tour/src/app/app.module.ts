import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HeroesComponent } from './heroes/heroes.component';
import { MessagesComponent } from './messages/messages.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { HeroSearchComponent } from './hero-search/hero-search.component';
import { HeroRegisterComponent } from './hero-register/hero-register.component';
import { MainPageComponent } from './main-page/main-page.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { JwtModule } from '@auth0/angular-jwt';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';

export function tokenGetter() {
  return localStorage.getItem('jwtToken'); // Schimbați acest lucru în funcție de locul unde păstrați token-ul JWT.
}


@NgModule({
  declarations: [
    AppComponent,
    HeroesComponent,
    MessagesComponent,
    HeroSearchComponent,
    HeroRegisterComponent,
    MainPageComponent,
    LoginComponent,
    RegisterComponent,
    UserDetailComponent,
    HeroDetailComponent,
  ],
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['example.com'],}}),
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
