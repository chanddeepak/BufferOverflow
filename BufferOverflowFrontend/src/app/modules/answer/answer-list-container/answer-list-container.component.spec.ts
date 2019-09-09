import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnswerListContainerComponent } from './answer-list-container.component';

describe('AnswerListContainerComponent', () => {
  let component: AnswerListContainerComponent;
  let fixture: ComponentFixture<AnswerListContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnswerListContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnswerListContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
