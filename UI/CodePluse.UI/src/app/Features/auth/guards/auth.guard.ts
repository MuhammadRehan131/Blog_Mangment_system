import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LoginSerivesService } from '../login/Services/login-serives.service';
import jwt_decode from 'jwt-decode';

export const authGuard: CanActivateFn = (route, state) => {
  const  cookieServices =inject(CookieService);
  const  authServices =inject(LoginSerivesService);
  const  router =inject(Router);
  const user=authServices.getUser();

  //check foe jwt token
  let token=cookieServices.get('Authorization');

  if(token && user){
    token=token.replace('Bearer','');
   const decodetoken:any=jwt_decode(token);
  //Compaire Expiry Time
   const expirydate=decodetoken.exp*1000;
   const currentTime=new Date().getTime();
   if(expirydate<currentTime)
   {
    authServices.LogOut();
    return router.createUrlTree(['/login'],{queryParams:{returnUrl :state.url}})
   }
   else{
// valid 
    if(user.roles.includes('Writer')){
      return true;
    }
    else{
      alert('UnAuthorizaed');
      return false;
     }
   }
    
  }
  else{
     authServices.LogOut();
    return router.createUrlTree(['/login'],{queryParams:{returnUrl :state.url}})
  }
};
