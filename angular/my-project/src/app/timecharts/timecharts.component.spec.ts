import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimechartsComponent } from './timecharts.component';

describe('TimechartsComponent', () => {
  let component: TimechartsComponent;
  let fixture: ComponentFixture<TimechartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimechartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimechartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
