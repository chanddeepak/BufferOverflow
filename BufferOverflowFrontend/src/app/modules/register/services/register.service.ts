import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/shared/models/User.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  url: string;
  constructor(private httpClient: HttpClient) {
    this.url = 'http://localhost:57557/';
  }

  createUser(user: User) {
    return this.httpClient.post<string>(this.url + 'api/user/register', user);
  }
}
