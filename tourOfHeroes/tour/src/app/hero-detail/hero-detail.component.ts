import { Component, OnInit} from '@angular/core';
import { Hero } from '../interfaces/hero';
import { ActivatedRoute } from '@angular/router';
import { HeroesService } from '../service/hero-service/heroes.service';
import { Subject, takeUntil, throwError } from 'rxjs';
import { User } from '../interfaces/user';
import { UserService } from '../service/user-service/user.service';
import { HeroToUser } from '../interfaces/hero-to-user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.scss']
})
export class HeroDetailComponent implements OnInit{
  hero?: Hero;
  heroId?: number;
  private destroy$ = new Subject<void>();
  complexity: number[] = [];
  complexityNumber: number = 0;
  attributeUrl: string = 'https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/icons/hero_';
  
  ngOnInit(): void {
    this.getHero();
  }

  getHero(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.heroesService.getHero(id)
      .pipe(takeUntil(this.destroy$))
      .subscribe((hero) => {
        this.hero = hero;
        this.attributeUrl += this.hero?.attribute.toLocaleLowerCase() + '.png';
        this.heroId = hero.id;
        this.complexityNumber = Number.parseInt(this.hero?.complexity);
        this.complexity = Array.from({ length: this.complexityNumber }, (_, index) => index);
    });
  }

  getLoggedInUser(): User{
    return this.userService.getUserFromLocalStorage();;
  }

  addHeroToUser(): void{
    const userId = this.getLoggedInUser().id;
    console.log(userId);
    if(this.heroId != null)
    {
      const heroToUser: HeroToUser = {
        userId: userId,
        heroId: this.heroId
      }

      this.heroesService.addHeroToUser(heroToUser).subscribe();
      this.router.navigate(['/heroes']);
    }

  }

  isUserAuthenticated(): boolean {
    return this.userService.isUserAuthenticated();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private heroesService: HeroesService,
    private router: Router
  ) {}
}