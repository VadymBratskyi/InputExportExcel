import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TerraTimerComponent } from './terra-timer.component';

describe('TerraTimerComponent', () => {
  let component: TerraTimerComponent;
  let fixture: ComponentFixture<TerraTimerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TerraTimerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TerraTimerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
