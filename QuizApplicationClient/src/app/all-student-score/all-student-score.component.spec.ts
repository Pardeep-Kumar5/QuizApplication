import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllStudentScoreComponent } from './all-student-score.component';

describe('AllStudentScoreComponent', () => {
  let component: AllStudentScoreComponent;
  let fixture: ComponentFixture<AllStudentScoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllStudentScoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllStudentScoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
