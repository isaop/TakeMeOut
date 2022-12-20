import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupBaComponent } from './signup-ba.component';

describe('SignupBaComponent', () => {
  let component: SignupBaComponent;
  let fixture: ComponentFixture<SignupBaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignupBaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignupBaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
