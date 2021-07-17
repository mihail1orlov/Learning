import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestRefreshComponent } from './test-refresh.component';

describe('TestRefreshComponent', () => {
  let component: TestRefreshComponent;
  let fixture: ComponentFixture<TestRefreshComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestRefreshComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestRefreshComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
