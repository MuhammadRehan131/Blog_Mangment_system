import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Features/auth/Model/user.model';
import { LoginSerivesService } from 'src/app/Features/auth/login/Services/login-serives.service';

@Component({
  selector: 'app-nvarbar',
  templateUrl: './nvarbar.component.html',
  styleUrls: ['./nvarbar.component.css']
})
export class NvarbarComponent implements OnInit {

  user?: User;
 
 constructor(private loginservices:LoginSerivesService,private router:Router){}
 
  ngOnInit(): void {
    this.loginservices.user().subscribe({

      next:(resp)=>{
        this.user=resp;
      }
    });

    this.user=  this.loginservices.getUser();
  }

  OnLogOut():void{
    this.loginservices.LogOut();
    this.router.navigateByUrl('/admin/home')

  }

}
