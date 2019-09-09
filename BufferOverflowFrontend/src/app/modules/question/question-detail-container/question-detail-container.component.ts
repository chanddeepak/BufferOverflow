import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Questions } from 'src/app/shared/models/Questions.model';
import { Tags } from 'src/app/shared/models/Tags.model';
import { Data } from 'src/app/shared/models/Data.model';
import { QuestionService } from '../services/question.service';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-question-detail-container',
  templateUrl: './question-detail-container.component.html',
  styleUrls: ['./question-detail-container.component.css']
})
export class QuestionDetailContainerComponent implements OnInit {
  isLogin = false;
  dataExist = false;
  data: Data;
  currentUserId: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private questionService: QuestionService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      this.isLogin = true;
      this.currentUserId = JSON.parse(this.authService.getToken()).Id;
    }
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.getQuestionDetail(id);
  }

  getQuestionDetail(id: number) {
    this.questionService.getQuestionDetail(id).subscribe(response => {
      let res = JSON.parse(response);
      if (res.success) {
        this.data = res.data;
        this.dataExist = true;
      }
    });
  }

  editQuestion(data) {}

  deleteQuestion(id) {
    this.questionService.deleteQuestion(id).subscribe(
      response => {
        let res = JSON.parse(response);

        if (res.success) {
          alert('Question deleted successfully');
          this.router.navigate(['']);
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
