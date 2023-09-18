import { Injectable } from '@angular/core';
import { User } from 'src/app/interfaces/user';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { MessageService } from '../message-service/message.service';
import { catchError, tap } from 'rxjs/operators';
import { AuthenticatedResponse } from 'src/app/interfaces/autheticated-response'; 
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private usersUrl = 'https://localhost:44318/api/User';  // URL to web api
  private loginUrl: string = "https://localhost:44318/api/Authentificate/login";
  private registerUrl: string = "https://localhost:44318/api/Authentificate/register";
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private router: Router, 
    private messageService: MessageService,
    private http: HttpClient
    ) { }

  getUsers(): Observable<User[]>{
     
    return this.http.get<User[]>(this.usersUrl)
    .pipe(
      tap(heroes => {
        this.log('fetched users');
        console.log('User:' + heroes)
      }),
      catchError(this.handleError<User[]>('getUser', []))
    );
  }

  getUserIdByName(userName: string): Observable<number>{
    return this.http.get<number>(this.usersUrl + '/FindUser?name=' + userName)
    .pipe(
      tap(userId => {
        this.log('fetched User Id from user' + userName);
        console.log('User id:' + userId)
      }),
      catchError(this.handleError<number>('getUserIdByName', 0))
    );
  } 

  register(user: User): void {
      this.http.post<User>(this.registerUrl, user, this.httpOptions)
    .subscribe({
      next: () => {
        this.login(user);
        this.saveUserToStorage(user);
        this.router.navigate(["/"]);
      }
    })
  }

  login( 
    credentials : User) : boolean {
      var invalidLogin = false;
      this.http.post<AuthenticatedResponse>(this.loginUrl, credentials, this.httpOptions)
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          credentials.id = this.userId(token);
          this.saveUserToStorage(credentials);
          localStorage.setItem("jwt", token); 
          this.router.navigate(["/"]);
        },
        error: (err: HttpErrorResponse) => invalidLogin = true
      });

      return invalidLogin;
  }

  userId(token: string): number {

    if (token) {
      const tokenParts = token.split('.');
      
      if (tokenParts.length === 3) {
        const payload = JSON.parse(atob(tokenParts[1]));
        const userId = payload.Id;

        return userId || 0; 
      }
    }
    return 0;
  }


  saveUserToStorage(user: User): void {
    localStorage.setItem("user", JSON.stringify(user));
  }

  getUserFromLocalStorage(): User {
    const storedUserString  = localStorage.getItem("user");

    if(storedUserString != null) {
      return JSON.parse(storedUserString);
    }

    return {name: '', email: '', password: ''} as User;
  }

  isUserAuthenticated = (): boolean => {
    return (localStorage.getItem("jwt") != null);
  }

  /** Log a message with the MessageService */
  private log(message: string) {
    this.messageService.add(`HeroService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
