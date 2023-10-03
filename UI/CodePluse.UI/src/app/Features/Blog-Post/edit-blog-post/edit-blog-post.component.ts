import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import BlogPostService from '../Services/blog-post.service';
import { BlogPost } from '../models/BlogPost.model';
import { Observable, Subscription } from 'rxjs';
import { CategoryServicesService } from '../../Category/Services/category-services.service';
import { Category } from '../../Category/Models/Category.model';
import { UpdateBlogPost } from '../models/Update-BlogPost.model';
import { ImgeSelectorService } from 'src/app/Sheard/Components/image-selectore/imge-selector.service';
 


@Component({
  selector: 'app-edit-blog-post',
  templateUrl: './edit-blog-post.component.html',
  styleUrls: ['./edit-blog-post.component.css']
})
export class EditBlogPostComponent implements OnInit,OnDestroy{
   
  id:string|null=null;
  model?:BlogPost;
  RouteSubscription?:Subscription;
  SubSubscription?:Subscription;
  ImageSubSubscription?:Subscription;
  category$?:Observable<Category[]>;
  selectedCategory?:string[];
  isImageSelectoer:boolean=false;

  constructor(private route:ActivatedRoute,
    private blogpostservices:BlogPostService,
    private router:Router ,
     private categoryservices:CategoryServicesService ,
     private imageservice:ImgeSelectorService)
   {
 
   }
  ngOnInit(): void {

    this.category$= this.categoryservices.GetAllCategory();
    this.route.paramMap.subscribe({
      next:(params)=>{
      this.id=params.get('id');
      if(this.id)
      {
       this.RouteSubscription= this.blogpostservices.GetBlogPostById(this.id)
        .subscribe({
         next:(responce)=>{
           this.model=responce;
           this.selectedCategory=responce.categories.map(x=>x.id);
         }
        });
      } 
      this.ImageSubSubscription= this.imageservice.Onselectimage().subscribe({
        next:(responce)=>{
          if(this.model){
           this.model.featureImaheUrl=responce.url;
           this.isImageSelectoer=false;
          }
        }
      });
      }
       });
      }


OnUpdateForm():void{
  if(this.model && this.id){
    var  updateBlogpost:UpdateBlogPost={
      title : this.model.title,
      discription: this.model.discription,
      content : this.model.content,
      featureImaheUrl : this.model.featureImaheUrl,
      isVisable : this.model.isVisable,
      author : this.model.author,
      urlHandle : this.model.urlHandle,
      publishedDate : this.model.publishedDate,
    categories : this.selectedCategory?? [],
  };
  this.SubSubscription= this.blogpostservices.UpdateBlogPost(this.id,updateBlogpost).subscribe({
    next:(responce)=>{
      this.router.navigateByUrl('/admin/BlogPost');
    }
   });
} 
}


ngOnDestroy(): void {
  this.RouteSubscription?.unsubscribe();
  this.SubSubscription?.unsubscribe();
  this.ImageSubSubscription?.unsubscribe();
}


openImgaeselectormodel():void{

this.isImageSelectoer=true;
}


closemodel():void{
  this.isImageSelectoer=false;
}


Ondelete():void{
  if (this.id){
    this.blogpostservices.Delete(this.id).subscribe({
     next:(responce)=>{
      this.router.navigateByUrl('/admin/BlogPost');
     }
    });
  }
  
}
}
