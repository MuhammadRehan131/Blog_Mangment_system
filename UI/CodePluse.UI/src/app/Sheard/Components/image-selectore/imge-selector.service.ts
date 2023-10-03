import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
 
import { HttpClient } from '@angular/common/http';
import { BlogImage } from './models/Blog-Image.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImgeSelectorService {
  selectedimage:BehaviorSubject<BlogImage>=new BehaviorSubject<BlogImage>({
    id:'',
    fileExtionsion:'',
    fileName:'',
    title:'',
    url:''
  });

  constructor( private http:HttpClient) {}

UploadImages(file:File , fileName:string ,title:string):Observable<BlogImage> {
  const formData=new FormData();
  formData.append('file',file);
  formData.append('fileName',fileName);
  formData.append('title',title);
return this.http.post<BlogImage>(`${environment.APIBaseURL}/BlogImages/CreateBlogImages`,formData)
}
GetAllBlogImages():Observable<BlogImage[]>{
  return this.http.get<BlogImage[]>(`${environment.APIBaseURL}/BlogImages/GetAllImags`);
}
selectImage(image:BlogImage):void{
this.selectedimage.next(image);
}

Onselectimage():Observable<BlogImage>{
  return this.selectedimage.asObservable()
}
 
 
   
}
