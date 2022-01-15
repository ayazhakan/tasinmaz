import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KullaniciekleComponent } from './kullaniciekle.component';

describe('KullaniciekleComponent', () => {
  let component: KullaniciekleComponent;
  let fixture: ComponentFixture<KullaniciekleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KullaniciekleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KullaniciekleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
