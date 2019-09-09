import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionDetailContainerComponent } from './question-detail-container.component';

describe('QuestionDetailContainerComponent', () => {
  let component: QuestionDetailContainerComponent;
  let fixture: ComponentFixture<QuestionDetailContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionDetailContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionDetailContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
