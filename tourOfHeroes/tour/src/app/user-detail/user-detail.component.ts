import { Component } from '@angular/core';
import { User } from '../interfaces/user';
import { Hero } from '../interfaces/hero';
import { UserService } from '../service/user-service/user.service';
import { HeroesService } from '../service/hero-service/heroes.service';
import { Subject } from 'rxjs';
import { HeroToUser } from '../interfaces/hero-to-user';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent {
  loggedUser: User = {id: 0, name: '', email: '', password: '', heroToUsers: []}
  userId: number = 0;
  heroes: Hero[] = [];
  selectedHero?: Hero;
  private destroy$ = new Subject<void>();

  constructor(
    private heroService: HeroesService,
    private userService: UserService,
    ) {}


  // Add a method to handle hero selection
  onSelect(hero: any) {
    if (!this.selectedHero != hero) {
      this.selectedHero = hero;
    } 
  }


  ngOnInit(): void {
    this.loggedUser = this.userService.getUserFromLocalStorage();
    this.userService.getUserIdByName(this.loggedUser.name)
        .subscribe((userId: number) => {
          this.userId = userId
          this.heroService.getHeroToUserList(this.userId)
          .subscribe(heroes => this.heroes = heroes);
        });

  }

  deleteHeroFromUser(hero: Hero): void{
      const heroToUser: HeroToUser ={
        heroId: hero.id,
        userId: this.userId
      };
      this.heroService.removeheroFromUser(heroToUser).subscribe();
      let i = this.heroes.findIndex(elem => elem == hero);
      this.heroes.splice(i,1);
  }

  ngOnDestroy(){
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }
}
