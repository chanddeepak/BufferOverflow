import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/models/User.model';
import { AuthService } from '../services/auth.service';
import { DataSharingService } from 'src/app/shared/services/data-sharing.service';

@Component({
  selector: 'app-login-container',
  templateUrl: './login-container.component.html',
  styleUrls: ['./login-container.component.css']
})
export class LoginContainerComponent implements OnInit {
  loginForm: FormGroup;
  globalResponse: string;
  user: User;

  constructor(
    private router: Router,
    private authService: AuthService,
    private dataSharing: DataSharingService
  ) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      Email: new FormControl('', [
        Validators.required,
        Validators.pattern(/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/)
      ]),
      Password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    const user = this.loginForm.value;
    // this.user.Email = user.Email;
    // this.user.Password = user.Password;
    this.loginUser(user);
  }

  loginUser(user) {
    debugger;
    this.authService.loginUser(user).subscribe(
      response => {
        debugger;
        //const res = JSON.parse(response);
        this.globalResponse = JSON.stringify(response);
        alert('Login Successfully');
      },
      err => {
        console.log(err);
      },
      () => {
        this.authService.storeToken(this.globalResponse);
        // this.dataSharing.this.service.function.subscribe(arg => (this.property = arg));
        this.router.navigate(['']);
      }
    );
  }
}
