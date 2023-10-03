import { Component, OnInit, ViewChild } from '@angular/core';
import { ImgeSelectorService } from './imge-selector.service';
import { Observable } from 'rxjs';
import { BlogImage } from './models/Blog-Image.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-image-selectore',
  templateUrl: './image-selectore.component.html',
  styleUrls: ['./image-selectore.component.css']
})
export class ImageSelectoreComponent implements OnInit {

  private file?:File;
fileName:string='';
title:string='';
BlogImages$?:Observable<BlogImage[]>;
@ViewChild('form',{static:false}) imageUploadForm?:NgForm;


  constructor(private imageservice:ImgeSelectorService){}
 
 
 
 
  ngOnInit(): void {
    this.getImages();
  }
OnfileUploadChang(event:Event):void{
 const element=event.currentTarget as HTMLInputElement;
 this.file=element.files?.[0];
}
UploadImags():void{
  if (this.file && this.fileName !=='' && this.title !=='')
  {
    this.imageservice.UploadImages(this.file,this.fileName,this.title).subscribe({
      next:(responce)=>{
        this.imageUploadForm?.resetForm ();
        this.getImages();
      }


    });
  }
}

private getImages(){
  this.BlogImages$= this.imageservice.GetAllBlogImages();
}
selectImage(image:BlogImage):void{
this.imageservice.selectImage(image);
}
 
}
