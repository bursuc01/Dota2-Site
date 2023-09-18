import { Injectable } from '@angular/core';
import { Hero } from 'src/app/interfaces/hero';
import { Observable, of, throwError } from 'rxjs';
import { MessageService } from '../message-service/message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap, throwIfEmpty } from 'rxjs/operators';
import { HeroToUser } from 'src/app/interfaces/hero-to-user';
import { UserService } from '../user-service/user.service';

@Injectable({
  providedIn: 'root'
})
export class HeroesService {
  private heroesUrl = 'https://localhost:44318/api/Hero';  // URL to web api
  private heroToUserUrl = 'https://localhost:44318/api/HeroToUser?userId=';
  private addHeroTOUserUrl = 'https://localhost:44318/api/HeroToUser';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private userService: UserService,
    private messageService: MessageService,
    private http: HttpClient
  ) { }

  getHeroToUserList(userId: number): Observable<Hero[]>{
    return this.http.get<Hero[]>(this.heroToUserUrl + userId)
    .pipe(
      tap(heroes => {
        this.log('fetched heroes from user {userId}');
        console.log('Heores:' + heroes)
      }),
      catchError(this.handleError<Hero[]>('getHeroesToUserList', []))
    );
  }

  getHeroes(): Observable<Hero[]>{
     return this.http.get<Hero[]>(this.heroesUrl)
    .pipe(
      tap(heroes => {
        this.log('fetched heroes');
        console.log('Heores:' + heroes)
      }),
      catchError(this.handleError<Hero[]>('getHeroes', []))
    );
  }

  /** GET hero by id. Will 404 if id not found */
  getHero(id: number): Observable<Hero> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.get<Hero>(url)
    .pipe(
      tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<Hero>(`getHero id=${id}`))
    );
  }
    /** Log a HeroService message with the MessageService */
    private log(message: string) {
    this.messageService.add(`HeroService: ${message}`);
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
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

  /** PUT: update the hero on the server */
  updateHero(hero: Hero): Observable<any> {
    const url = `${this.heroesUrl}/${hero.id}`; // Construct the URL with the hero's ID
    return this.http.put(url, hero, this.httpOptions)
    .pipe(
      tap(_ => this.log(`updated hero id=${hero.id}`)),
      catchError(this.handleError<any>('updateHero'))
    );
  }

  addHero(hero: Hero): Observable<Hero>{
    return this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions)
    .pipe(
      tap((newHero: Hero) => this.log("added hero w/ id=${newHero.id}")),
      catchError(this.handleError<Hero>('addHero'))
    );
  }

  deleteHero(id: number): Observable<Hero> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.delete<Hero>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted hero id=${id}`)),
      catchError(this.handleError<Hero>('deleteHero'))
    );
  }

  /* GET heroes whose name contains search term */
  searchHeroes(term: string): Observable<Hero[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Hero[]>(`${this.heroesUrl}/?name=${term}`).pipe(
      tap(x => x.length ?
        this.log(`found heroes matching "${term}"`) :
        this.log(`no heroes matching "${term}"`)),
      catchError(this.handleError<Hero[]>('searchHeroes', []))
    );
  }

  addHeroToUser(heroToUser: HeroToUser): Observable<any> {
    console.log(heroToUser.userId);
    return this.http.post<HeroToUser>(this.addHeroTOUserUrl, heroToUser, this.httpOptions);
  }

  removeheroFromUser(heroToUser: HeroToUser): Observable<any> {
    const deleteUrl = this.addHeroTOUserUrl + '?heroId=' + heroToUser.heroId + '&userId=' + heroToUser.userId;
    return this.http.delete<HeroToUser>(deleteUrl, this.httpOptions);
  }
}
