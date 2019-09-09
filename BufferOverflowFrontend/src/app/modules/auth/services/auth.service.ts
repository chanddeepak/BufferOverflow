import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { observable, of, throwError, pipe } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';
import { User } from 'src/app/shared/models/User.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string;
  errorHandler;
  constructor(private httpClient: HttpClient) {
    this.url = 'http://localhost:57557/';
  }

  loginUser(user: any) {
    debugger;
    let userData = 'username=' + user.Email + '&password=' + user.Password + '&grant_type=password';

    let reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
      'No-Auth': 'True'
    });

    return this.httpClient
      .post(this.url + 'token', userData, {
        headers: reqHeader
      })
      .pipe(
        map(res => res),
        catchError(this.errorHandler)
      );
  }

  public isAuthenticated(): boolean {
    return this.getToken() != null;
  }
  storeToken(token: string) {
    localStorage.setItem('token', token);
  }
  getToken() {
    return localStorage.getItem('token');
  }
  removeToken() {
    return localStorage.removeItem('token');
  }

  createUser(user: User) {
    return this.httpClient.post<string>(this.url + 'api/user/register', user);
  }
}
