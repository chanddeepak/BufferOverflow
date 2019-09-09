import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnswerInputContainerComponent } from './answer-input-container.component';

describe('AnswerInputContainerComponent', () => {
  let component: AnswerInputContainerComponent;
  let fixture: ComponentFixture<AnswerInputContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnswerInputContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnswerInputContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
