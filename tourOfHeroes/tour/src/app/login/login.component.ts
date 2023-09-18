import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../interfaces/user';
import { UserService } from '../service/user-service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  
  invalidLogin: boolean = false;
  credentials: User = {id:0, name:'', password:'', email: '', heroToUsers: []};

  constructor(
    private userService: UserService
    ) { }

  ngOnInit(): void {
    
    console.log(JSON.stringify(this.credentials));
  }

  login = ( form: NgForm) => {
    if (form.valid) {
      this.invalidLogin = this.userService.login( this.credentials); 
    }
  }
}