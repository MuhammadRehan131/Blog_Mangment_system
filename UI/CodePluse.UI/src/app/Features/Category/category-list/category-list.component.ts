import { Component, OnInit } from '@angular/core';
import { CategoryServicesService } from '../Services/category-services.service';
import { Category } from '../Models/Category.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  // categoriest? : Category[];
  Categories$?:Observable<Category[]>;
  constructor(private categoryservices:CategoryServicesService){

  }
  ngOnInit(): void {
     this. Categories$= this.categoryservices.GetAllCategory();
    // .subscribe({
    // //   next:(response)=>{
    // //     this.categoriest=response;
    // //   },
     
    // //  })
  }
  


}
