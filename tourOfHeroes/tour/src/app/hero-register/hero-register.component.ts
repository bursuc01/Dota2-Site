import { Component } from '@angular/core';
import { Hero } from '../interfaces/hero';
import { HeroesService } from '../service/hero-service/heroes.service';
import { Subject, takeUntil } from 'rxjs';
import { Location } from '@angular/common';

@Component({
  selector: 'app-hero-register',
  templateUrl: './hero-register.component.html',
  styleUrls: ['./hero-register.component.scss']
})
export class HeroRegisterComponent {
  private destroy$ = new Subject<void>();

  constructor(
    private heroesService: HeroesService,
    private location: Location,
  ) {}

  goBack(): void {
    this.location.back();
  }

  add(name: string, power: string, backstory: string, photoUrl: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroesService.addHero({ name, power, backstory, photoUrl } as Hero)
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => this.goBack())
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
