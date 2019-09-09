import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AnswerService {
  url: string;
  constructor(private httpClient: HttpClient) {
    this.url = 'http://localhost:57557/api/';
  }

  createAnswer(data) {
    return this.httpClient.post<string>(this.url + 'answer/create', data);
  }

  getAnswers(questionId) {
    return this.httpClient.get<string>(this.url + `answer/${questionId}`);
  }

  deleteAnswer(id) {
    return this.httpClient.delete<string>(this.url + `answer/delete/${id}`);
  }

  createVote(vote) {
    return this.httpClient.post<string>(this.url + `answer/votes`, vote);
  }
}
