import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { QuestionService } from '../services/question.service';
import { Data } from 'src/app/shared/models/Data.model';
import { Questions } from 'src/app/shared/models/Questions.model';
import { Tags } from 'src/app/shared/models/Tags.model';
import { AuthService } from '../../auth/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-question-list-container',
  templateUrl: './question-list-container.component.html',
  styleUrls: ['./question-list-container.component.css']
})
export class QuestionListContainerComponent implements OnInit {
  dataList: Data[];
  currentUserId: number;
  isData = false;
  constructor(
    private questionService: QuestionService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      this.currentUserId = JSON.parse(this.authService.getToken()).Id;
    }
    this.getQuestionsList();
  }

  getQuestionsList() {
    this.questionService.getQuestions().subscribe(
      response => {
        const res = JSON.parse(response);
        if (res.success) {
          //debugger;
          this.dataList = res.data;
          this.isData = true;
        }
      },
      err => {
        console.log(err);
      }
    );
  }

  editQuestion(id) {
    this.router.navigate(['/question/edit', id]);
  }

  deleteQuestion(id) {
    this.questionService.deleteQuestion(id).subscribe(
      response => {
        let res = JSON.parse(response);

        if (res.success) {
          alert('Question deleted successfully');
          location.reload();
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
