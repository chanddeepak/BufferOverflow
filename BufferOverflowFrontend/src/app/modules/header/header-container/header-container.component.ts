import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/shared/services/data-sharing.service';

@Component({
  selector: 'app-header-container',
  templateUrl: './header-container.component.html',
  styleUrls: ['./header-container.component.css']
})
export class HeaderContainerComponent implements OnInit {
  isLogin = false;
  username: string;
  constructor(
    private router: Router,
    private authService: AuthService,
    public dataSharing: DataSharingService
  ) {
    if (this.dataSharing.get()) {
      this.ngOnInit();
    }
  }

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      const token = this.authService.getToken();
      console.log(token);
      this.isLogin = true;
    }
  }

  logOut() {
    this.authService.removeToken();
    this.isLogin = false;
    this.router.navigate(['/login']);
  }
}
