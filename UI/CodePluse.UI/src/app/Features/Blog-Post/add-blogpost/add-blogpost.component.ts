import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddBlogPost } from '../models/add-blogpost.model';
import BlogPostService from '../Services/blog-post.service';
import { Router } from '@angular/router';
import { CategoryServicesService } from '../../Category/Services/category-services.service';
import { Observable, Subscription } from 'rxjs';
import { Category } from '../../Category/Models/Category.model';
import { ImgeSelectorService } from 'src/app/Sheard/Components/image-selectore/imge-selector.service';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit ,OnDestroy {
  model:AddBlogPost;
  categories$?:Observable<Category[]>;
  isImageSelectoer:boolean=false;
  ImageSubSubscription?:Subscription;


  constructor(private blogservices:BlogPostService ,
     private router:Router , 
     private imageservice:ImgeSelectorService,
      private categoryserivces:CategoryServicesService){
this.model={
  title:'',
  discription:'',
  content: '',
  featureImaheUrl: '',
  urlHandle: '',
  author: '',
  publishedDate:new Date(),
  isVisable:true,
  categories:[]
}
}
 
   OnSubmitForm():void{
    debugger
    this.blogservices.AddBlogPost(this.model).subscribe({
   next:(responce)=>
       {
     this.router.navigateByUrl('/admin/BlogPost');
       }
     });
  }


  ngOnInit(): void {
   this.categories$=  this.categoryserivces.GetAllCategory();
  this.ImageSubSubscription= this.imageservice.Onselectimage().subscribe({
    next:(responce)=>{
      this.model.featureImaheUrl=responce.url;
      this.closemodel();
    }
   });
  }
  openImgaeselectormodel():void{

    this.isImageSelectoer=true;
    }
    
    
    closemodel():void{
      this.isImageSelectoer=false;
    }
    ngOnDestroy(): void {
       
      this.ImageSubSubscription?.unsubscribe();
    }
    

}
