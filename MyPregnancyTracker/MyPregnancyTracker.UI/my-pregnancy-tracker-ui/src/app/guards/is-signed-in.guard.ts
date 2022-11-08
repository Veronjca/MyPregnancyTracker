import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class IsSignedInGuard implements CanActivate {

  constructor(private authService: AuthService,
    private router: Router) {
     }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,): boolean{
      if(this.authService.isLoggedIn()){
        this.router.navigate([`/user/${this.authService.getUserId()}`]);
        return false;
      }

      return true;
  }
}
