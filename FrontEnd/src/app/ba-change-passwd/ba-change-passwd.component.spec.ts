import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaChangePasswdComponent } from './ba-change-passwd.component';

describe('BaChangePasswdComponent', () => {
  let component: BaChangePasswdComponent;
  let fixture: ComponentFixture<BaChangePasswdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaChangePasswdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BaChangePasswdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
