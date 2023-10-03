import { Injectable } from '@angular/core';
import { AddCatgoryes } from '../Models/Add-category.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../Models/Category.model';
import { environment } from 'src/environments/environment';
import { UpdateCategory } from '../Models/update-category.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class CategoryServicesService {

  constructor(private http:HttpClient, private cookieServices:CookieService) { }


 
  GetAllCategory():Observable<Category[]>{
  return this.http.get<Category[]>(`${environment.APIBaseURL}/Category/GetAll`);
  }
  GetCategoryById(id:string):Observable<Category>{
    return this.http.get<Category>(`${environment.APIBaseURL}/Category/${id}`);
   
  }



  UpdateCategory(id:string,updatecategory:UpdateCategory):Observable<Category>
  {
    return this.http.put<Category>(`${environment.APIBaseURL}/Category/${id}?addAuth=true`,updatecategory);
  }
  DeleteCategory(id:string) :Observable<Category> {
   return this.http.delete<Category>(`${environment.APIBaseURL}/Category/${id}?addAuth=true`);
  }
  Addcategories(model:AddCatgoryes):Observable<void> {
    return this.http.post<void> (`${environment.APIBaseURL}/Category/CreateCategory?addAuth=true`,model);
  }
}
