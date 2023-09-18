import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroRegisterComponent } from './hero-register.component';

describe('HeroRegisterComponent', () => {
  let component: HeroRegisterComponent;
  let fixture: ComponentFixture<HeroRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeroRegisterComponent]
    });
    fixture = TestBed.createComponent(HeroRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
