import { Component, OnInit } from '@angular/core';
import { Hero } from '../interfaces/hero';
import { HeroesService } from '../service/hero-service/heroes.service';
import { UserService } from '../service/user-service/user.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.scss']
})

export class HeroesComponent implements OnInit{
  backupHeroes: Hero[] = [];
  heroes: Hero[] = [];
  selectedHero: any;
  selectedAttribute: any;
  selectedComplexity: any;
  private destroy$ = new Subject<void>();

  onSelect(hero: any) {
    this.selectedHero = hero;
  }

  onHeroSelect(hero: any) {
      this.selectedHero = hero;
      console.log(this.selectedHero.id);
  }

  isUserAuthenticated(): boolean {
    return this.userService.isUserAuthenticated();
  }

  getHeroes(): void {
    this.heroesService.getHeroes()
        .subscribe(heroes => {
          this.heroes = heroes;
          this.backupHeroes = heroes;
        });
    this.heroes.forEach(x=>console.log("elem: " + x));
  }

  handleAttributeClick(str: string): void{
    this.heroes = this.backupHeroes; 
    this.heroes = this.heroes.filter(elem => elem.attribute.toLowerCase() == str);
  }

  handleComplexityClick(str: string): void{
    this.heroes = this.backupHeroes;
    this.heroes = this.heroes.filter (elem => elem.complexity == str);
  }

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroesService.deleteHero(hero.id).subscribe();
  }

  ngOnDestroy(): void{
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }

  ngOnInit(): void {
    this.getHeroes();
  }

  constructor(
    private heroesService: HeroesService,
    private userService: UserService
    ) {}
  
}
