import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../../Model/login.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginResponce } from '../../Model/login-responce.model';
import { environment } from 'src/environments/environment';
import { User } from '../../Model/user.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class LoginSerivesService { 

  $user=new BehaviorSubject<User | undefined>(undefined);

  constructor(private http:HttpClient, private cookieServices:CookieService) { }

  Login(request:Login):Observable<LoginResponce> {
    return this.http.post<LoginResponce> (`${environment.APIBaseURL}/Auth/Login`,{email:request.email,password:request.password});
  }

 setUser(user:User):void{

  this.$user.next(user);
  localStorage.setItem('user-email',user.email);
  localStorage.setItem('user-roles',user.roles.join(','));
 }

user():Observable<User | undefined>{
  return this.$user.asObservable();
}

LogOut():void{
  localStorage.clear();
  this.cookieServices.delete('Authorization','/');
  this.$user.next(undefined);
}
getUser():User|undefined{
  const email=localStorage.getItem('user-email');
  const roles=localStorage.getItem('user-roles');

  if(email && roles){
    const user:User={
     email:email,
     roles:roles?.split(',')

    };
    return user;
  }
  return undefined;
}


}
 