import { Component, OnInit } from '@angular/core';
import BlogPostService from '../../Blog-Post/Services/blog-post.service';
import { BlogPost } from '../../Blog-Post/models/BlogPost.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  Blogpost$?:Observable<BlogPost[]>;
  constructor(private blogpostservices:BlogPostService){}



  ngOnInit(): void {
   this.Blogpost$= this.blogpostservices.GetAllBlogPost();
  }

  

}
