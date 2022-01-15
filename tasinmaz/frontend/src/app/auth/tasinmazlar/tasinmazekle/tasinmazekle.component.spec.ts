import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TasinmazekleComponent } from './tasinmazekle.component';

describe('TasinmazekleComponent', () => {
  let component: TasinmazekleComponent;
  let fixture: ComponentFixture<TasinmazekleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TasinmazekleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TasinmazekleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
