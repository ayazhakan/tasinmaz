import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoglarComponent } from './loglar.component';

describe('LoglarComponent', () => {
  let component: LoglarComponent;
  let fixture: ComponentFixture<LoglarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoglarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoglarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
