import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaEditComponent } from './ba-edit.component';

describe('BaEditComponent', () => {
  let component: BaEditComponent;
  let fixture: ComponentFixture<BaEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BaEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
