import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AnswerService } from '../services/answer.service';
import { Answers } from 'src/app/shared/models/Answers.model';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-answer-input-container',
  templateUrl: './answer-input-container.component.html',
  styleUrls: ['./answer-input-container.component.css']
})
export class AnswerInputContainerComponent implements OnInit {
  @Input() QuestionId: number;
  UserId: number;
  answerInputForm: FormGroup;
  constructor(
    private answerService: AnswerService,
    private router: Router,
    private authService: AuthService
  ) {
    if (this.authService.isAuthenticated()) {
      debugger;
      this.UserId = JSON.parse(this.authService.getToken()).Id;
    }
  }

  ngOnInit() {
    this.answerInputForm = new FormGroup({
      Answer: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    const answer = this.answerInputForm.value;

    answer.UserId = this.UserId;
    answer.QuestionId = this.QuestionId;

    this.createAnswer(answer);
  }
  createAnswer(answer: Answers) {
    this.answerService.createAnswer(answer).subscribe(response => {
      const res = JSON.parse(response);

      if (res.success) {
        //   this.router.navigate([`/question`]);
        location.reload();
        alert('Answer created successfully');
      }
    });
  }
}
