import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Data } from 'src/app/shared/models/Data.model';
import { Questions } from 'src/app/shared/models/Questions.model';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  url: string;
  header: any;
  constructor(private httpClient: HttpClient) {
    this.url = 'http://localhost:57557/api/';
    const headerSettings: { [name: string]: string | string[] } = {};
    this.header = new HttpHeaders(headerSettings);
  }

  createQuestion(data: Questions) {
    // const body = JSON.stringify(data);
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    //  var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    return this.httpClient.post<string>(this.url + 'question/create', data, httpOptions);
  }

  createTags(tags, id) {
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
      'No-Auth': 'True'
    });
    return this.httpClient.post<string>(this.url + `tag/create/${id}`, tags);
  }

  getQuestions() {
    // var reqHeader = new HttpHeaders({
    //   'Content-Type': 'application/x-www-form-urlencoded',
    //   'No-Auth': 'True'
    // });
    return this.httpClient.get<string>(this.url + 'question');
  }

  getQuestionDetail(id) {
    // var reqHeader = new HttpHeaders({
    //   'Content-Type': 'application/x-www-form-urlencoded',
    //   'No-Auth': 'True'
    // });
    return this.httpClient.get<string>(this.url + `question/details/${id}`);
  }

  editQuestion(question: Questions) {
    // var reqHeader = new HttpHeaders({
    //   'Content-Type': 'application/x-www-form-urlencoded',
    //   'No-Auth': 'True'
    // });
    return this.httpClient.put<string>(this.url + `question/edit`, question);
  }

  deleteQuestion(id) {
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
      'No-Auth': 'True'
    });
    return this.httpClient.delete<string>(this.url + `question/delete/${id}`, {
      headers: reqHeader
    });
  }
}
