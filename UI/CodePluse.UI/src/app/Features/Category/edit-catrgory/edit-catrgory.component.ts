import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryServicesService } from '../Services/category-services.service';
import { Category } from '../Models/Category.model';
import { UpdateCategory } from '../Models/update-category.model';

@Component({
  selector: 'app-edit-catrgory',
  templateUrl: './edit-catrgory.component.html',
  styleUrls: ['./edit-catrgory.component.css']
})
export class EditCatrgoryComponent implements OnInit,OnDestroy {

  id:string|null=null;
  categoriy?:Category
  UpdateCategorysub?:Subscription;
  paramsSubscription?:Subscription;


  constructor(private route:ActivatedRoute,
   private categoryservices:CategoryServicesService,private router:Router)
  {

  }

  ngOnInit(): void {
  this.paramsSubscription=  this.route.paramMap
  .subscribe({
            next:(params)=>{
            this.id=params.get('id');
            if(this.id)
            {
              debugger
              this.categoryservices.GetCategoryById(this.id)
              .subscribe({
               next:(responce)=>{
                 this.categoriy=responce;
               }
              });
            }

      }
    });
  }
  OnFormSubmit():void{
    const updatecategory:UpdateCategory={
      name:this.categoriy?.name??'',
      urlHandle: this.categoriy?.urlHandle??''

    };
    //service
    if (this.id){
  this.UpdateCategorysub=  this.categoryservices.UpdateCategory(this.id,updatecategory).subscribe({
      next:(responce)=>{
       this.router.navigateByUrl('/admin/category');
      }
    });
    }
  }
  Ondelete():void{
    if(this.id)
this.categoryservices.DeleteCategory(this.id)
.subscribe({
  next:(responce)=>{
    this.router.navigateByUrl('/admin/category');
  }
});
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.UpdateCategorysub?.unsubscribe();
  }
}
