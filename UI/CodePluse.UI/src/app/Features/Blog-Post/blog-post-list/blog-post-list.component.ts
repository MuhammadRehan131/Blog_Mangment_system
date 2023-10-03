import { Component, OnInit } from '@angular/core';
import BlogPostService from '../Services/blog-post.service';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/BlogPost.model';

@Component({
  selector: 'app-blog-post-list',
  templateUrl: './blog-post-list.component.html',
  styleUrls: ['./blog-post-list.component.css']
})
export class BlogPostListComponent implements OnInit {
 
  Blogpost$?:Observable<BlogPost[]>;
 constructor(private blogpostServices:BlogPostService){}
 
 
 
 
  ngOnInit(): void {
   this. Blogpost$= this.blogpostServices.GetAllBlogPost();
  }




}
