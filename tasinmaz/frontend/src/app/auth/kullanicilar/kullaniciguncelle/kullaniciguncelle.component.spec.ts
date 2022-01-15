import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KullaniciguncelleComponent } from './kullaniciguncelle.component';

describe('KullaniciguncelleComponent', () => {
  let component: KullaniciguncelleComponent;
  let fixture: ComponentFixture<KullaniciguncelleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KullaniciguncelleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KullaniciguncelleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
