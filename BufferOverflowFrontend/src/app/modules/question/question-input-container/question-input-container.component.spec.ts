import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionInputContainerComponent } from './question-input-container.component';

describe('QuestionInputContainerComponent', () => {
  let component: QuestionInputContainerComponent;
  let fixture: ComponentFixture<QuestionInputContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionInputContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionInputContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
