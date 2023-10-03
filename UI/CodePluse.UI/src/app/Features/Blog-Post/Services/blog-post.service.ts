import { Injectable } from '@angular/core';
import { AddBlogPost } from '../models/add-blogpost.model';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/BlogPost.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UpdateBlogPost } from '../models/Update-BlogPost.model';

@Injectable({
  providedIn: 'root'
})
export default class BlogPostService {

  constructor(private http:HttpClient) { }

  AddBlogPost(data:AddBlogPost):Observable<BlogPost>{
   return this.http.post<BlogPost>(`${environment.APIBaseURL}/BlogPost/CreateBlogPosts?addAuth=true`,data);
  }
  GetAllBlogPost():Observable<BlogPost[]>{
    return this.http.get<BlogPost[]>(`${environment.APIBaseURL}/BlogPost/GetAllBlogPost`);
  }
  GetBlogPostById(id:string):Observable<BlogPost>{
    return this.http.get<BlogPost>(`${environment.APIBaseURL}/BlogPost/${id}`);
  }

  UpdateBlogPost(id: string , updateBlogPost:UpdateBlogPost):Observable<BlogPost>
  {
    return this.http.put<BlogPost>(`${environment.APIBaseURL}/BlogPost/${id}?addAuth=true`,updateBlogPost);
}
Delete(id:string) :Observable<BlogPost> {
  return this.http.delete<BlogPost>(`${environment.APIBaseURL}/BlogPost/${id}?addAuth=true`);
 }
}
