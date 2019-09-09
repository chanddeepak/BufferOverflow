import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { User } from 'src/app/shared/models/User.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-container',
  templateUrl: './register-container.component.html',
  styleUrls: ['./register-container.component.css']
})
export class RegisterContainerComponent implements OnInit {
  registerForm: FormGroup;
  message: string;
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.registerForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [
        Validators.required,
        Validators.pattern(/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/)
      ]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
      image: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    const user = this.registerForm.value;
    this.createUser(user);
  }

  createUser(user: User) {
    //debugger;
    this.authService.createUser(user).subscribe(response => {
      const res = JSON.parse(response);
      if (res.success) {
        this.message = 'User registered successfully';
        alert(this.message);
        this.router.navigate(['/login']);
      } else {
        this.message = res.data;
      }
    });
  }
}
