import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { observable } from 'rxjs';
import { AuthService } from './modules/auth/services/auth.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}
  canActivate(): boolean {
    if (!this.auth.isAuthenticated()) {
      console.log('you are not authorized to view this page');
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
}
