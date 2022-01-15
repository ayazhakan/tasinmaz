import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TasinmazGuncelleComponent } from './tasinmaz-guncelle.component';

describe('TasinmazGuncelleComponent', () => {
  let component: TasinmazGuncelleComponent;
  let fixture: ComponentFixture<TasinmazGuncelleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TasinmazGuncelleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TasinmazGuncelleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
