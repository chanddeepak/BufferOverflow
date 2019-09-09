import { Component, OnInit, Input } from '@angular/core';
import { Data } from 'src/app/shared/models/Data.model';
import { AnswerService } from '../services/answer.service';
import { AuthService } from '../../auth/services/auth.service';
import { Router } from '@angular/router';
import { Votes } from 'src/app/shared/models/Votes.model';

@Component({
  selector: 'app-answer-list-container',
  templateUrl: './answer-list-container.component.html',
  styleUrls: ['./answer-list-container.component.scss']
})
export class AnswerListContainerComponent implements OnInit {
  @Input() QuestionId: number;
  dataList: Data[];
  currentUserId: number;
  vote;
  voteCount: number;
  userVote: number;

  isTrue = false;
  constructor(
    private answerService: AnswerService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      this.currentUserId = JSON.parse(this.authService.getToken()).Id;
    }
    this.voteCount = 0;
    this.getAnswersList();
  }
  getAnswersList() {
    this.answerService.getAnswers(this.QuestionId).subscribe(response => {
      const res = JSON.parse(response);
      if (res.success) {
        debugger;
        this.dataList = res.data;

        // const result = this.dataList.filter(s => {
        //   return s.VoteDetail.UserId === this.currentUserId;
        // });
        // if (result != null) {
        //   this.userVote = result
        // }
      }
    });
  }

  editAnswer(data) {}

  deleteAnswer(id) {
    this.answerService.deleteAnswer(id).subscribe(
      response => {
        let res = JSON.parse(response);

        if (res.success) {
          alert('Answer deleted successfully');
          location.reload();
        }
      },
      err => {
        console.log(err);
      }
    );
  }

  upvote(answerId) {
    let vote = new Votes();
    vote.Vote = 1;
    vote.UserId = this.currentUserId;
    vote.AnswerId = answerId;

    this.createVote(vote);
  }

  downvote(answerId) {
    let vote = new Votes();
    vote.Vote = 2;
    vote.UserId = this.currentUserId;
    vote.AnswerId = answerId;

    this.createVote(vote);
  }

  createVote(vote) {
    this.answerService.createVote(vote).subscribe(response => {
      let res = JSON.parse(response);

      if (res.success) {
        // debugger;
        // this.userVote = res.data.VoteDetail.Vote;
        // this.voteCount = res.data.TotalVote;
        // this.isTrue = true;
        this.ngOnInit();
      }
    });
  }
}
