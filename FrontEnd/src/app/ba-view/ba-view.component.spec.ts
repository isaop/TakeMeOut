import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaViewComponent } from './ba-view.component';

describe('BaViewComponent', () => {
  let component: BaViewComponent;
  let fixture: ComponentFixture<BaViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BaViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
