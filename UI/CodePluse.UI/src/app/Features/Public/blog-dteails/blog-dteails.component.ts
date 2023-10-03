import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-blog-dteails',
  templateUrl: './blog-dteails.component.html',
  styleUrls: ['./blog-dteails.component.css']
})
export class BlogDteailsComponent implements OnInit{
  url:string | null=null;
  constructor(private route:ActivatedRoute){}


  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        params.get('url');

      }
    });
    
  }



}
