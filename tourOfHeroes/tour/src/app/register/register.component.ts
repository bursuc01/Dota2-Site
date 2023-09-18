import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterModel } from '../interfaces/register-model';
import { UserService } from '../service/user-service/user.service';
import { User } from '../interfaces/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  url: string = "https://localhost:44318/api/Authentificate/login";
  credentials: RegisterModel = {id: 0, username:'', password:'', email: ''};

  constructor(
    private userService: UserService,
    private router: Router
    ) { }

  ngOnInit(): void {
    
  }

  register = ( form: NgForm) => {
    if (form.valid) {
      const newUser: User = {
        id: this.credentials.id,
        name: this.credentials.username,
        password: this.credentials.password,
        email: this.credentials.email,
        heroToUsers: []
      };
      this.userService.register(newUser);
    }
    this.router.navigate(['/']);
  }
}
