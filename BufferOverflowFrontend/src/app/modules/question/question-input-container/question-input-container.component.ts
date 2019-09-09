import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Questions } from 'src/app/shared/models/Questions.model';
import { Data } from 'src/app/shared/models/Data.model';
import { Tags } from 'src/app/shared/models/Tags.model';
import { QuestionService } from '../services/question.service';
import { AuthService } from '../../auth/services/auth.service';

@Component({
  selector: 'app-question-input-container',
  templateUrl: './question-input-container.component.html',
  styleUrls: ['./question-input-container.component.css']
})
export class QuestionInputContainerComponent implements OnInit {
  questionInputForm: FormGroup;
  tags: Array<Tags> = [];
  question: Questions;
  questionId: number;

  isEdit = false;

  constructor(
    private router: Router,
    private questionService: QuestionService,
    private authService: AuthService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.questionInputForm = new FormGroup({
      Title: new FormControl('', Validators.required),
      Description: new FormControl('', Validators.required),
      Tags: new FormControl('', Validators.required),
      Image: new FormControl('')
    });

    this.route.paramMap.subscribe(params => {
      this.questionId = +params.get('id');
      if (this.questionId) {
        this.getQuestionDetail(this.questionId);
      }
    });
  }

  getQuestionDetail(id) {
    this.questionService.getQuestionDetail(id).subscribe(response => {
      const res = JSON.parse(response);

      if (res.success) {
        const question = res.data.QuestionDetail;
        let tagArray = res.data.TagDetail;
        let tags = '';
        tagArray.forEach(item => {
          tags += item.Tag + ', ';
        });
        this.editQuestion(question, tags);
      }
    });
  }

  editQuestion(question: Questions, tags) {
    this.questionInputForm.patchValue({
      Title: question.Title,
      Description: question.Description,
      Tags: tags,
      Image: question.Image
    });
    this.isEdit = true;
  }

  onEdit() {
    const question = this.questionInputForm.value;

    question.Tags.split(',').map(item => {
      let tag = new Tags();
      tag.Tag = item.trim();
      this.tags.push(tag);
    });

    delete question.Tags;
    const UserId = JSON.parse(this.authService.getToken()).Id;
    question.UserId = UserId;
    question.Id = this.questionId;
    this.questionEdit(question);
  }

  questionEdit(question) {
    this.questionService.editQuestion(question).subscribe(response => {
      const res = JSON.parse(response);
      if (res.success) {
        //debugger;
        this.questionService.createTags(this.tags, res.data.Id).subscribe(response => {
          const res = JSON.parse(response);
          if (res.success) {
            alert('Question created successfully');
            this.router.navigate(['']);
          }
        });
      }
    });
  }

  onSubmit() {
    const question = this.questionInputForm.value;

    question.Tags.split(',').map(item => {
      let tag = new Tags();
      tag.Tag = item.trim();
      this.tags.push(tag);
    });

    delete question.Tags;
    const UserId = JSON.parse(this.authService.getToken()).Id;
    question.UserId = UserId;
    this.createQuestion(question);
  }

  createQuestion(data) {
    //debugger;
    this.questionService.createQuestion(data).subscribe(response => {
      const res = JSON.parse(response);
      if (res.success) {
        //debugger;
        this.questionService.createTags(this.tags, res.data.Id).subscribe(response => {
          const res = JSON.parse(response);
          if (res.success) {
            alert('Question created successfully');
            this.router.navigate(['']);
          }
        });
      }
    });
  }
}
