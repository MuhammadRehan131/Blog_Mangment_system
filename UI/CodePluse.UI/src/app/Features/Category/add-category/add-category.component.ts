import { Component, OnDestroy } from '@angular/core';
import { AddCatgoryes } from '../Models/Add-category.model';
import { CategoryServicesService } from '../Services/category-services.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

 model:AddCatgoryes;
 private addcategorySubscribtion?:Subscription;

constructor(private categoryservices:CategoryServicesService,private router:Router){
  this.model={
    name:'',
    urlHandle:''
  }
}
  


  OnSubmitForm(){
    this.addcategorySubscribtion= this.categoryservices.Addcategories(this.model).subscribe({
      next:(Response)=>{
        this.router.navigateByUrl('/admin/category');
      },
      error:(Response)=>{
        alert("It Was Bad");
      }
    })
  }

  ngOnDestroy(): void {
    this.addcategorySubscribtion?.unsubscribe();
  }

}
