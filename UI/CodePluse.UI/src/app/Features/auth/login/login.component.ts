import { Component } from '@angular/core';
import { Login } from '../Model/login.model';
import { LoginSerivesService } from './Services/login-serives.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private loginservices:LoginSerivesService,private router:Router , private cookieServices:CookieService){
    this.model={
      email:'',
      password:''
    }
  }
  model:Login;



  OnSubmit():void{
   this.loginservices.Login(this.model).subscribe({
    next:(responce)=>{
      // console.log(responce);
      //set cookie
      this.cookieServices.set('Authorization',`Bearer ${responce.token}`,
      undefined , '/' , undefined , true , 'Strict');

      //set user
      this.loginservices.setUser({
         email:responce.email,
         roles:responce.roles

      });

      this.router.navigateByUrl('/admin/home');
    }
   });
  }
}
