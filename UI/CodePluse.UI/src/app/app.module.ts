import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NvarbarComponent } from './Core/Components/nvarbar/nvarbar.component';
import { CategoryListComponent } from './Features/Category/category-list/category-list.component';
import { AddCategoryComponent } from './Features/Category/add-category/add-category.component';
import { FormsModule } from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { EditCatrgoryComponent } from './Features/Category/edit-catrgory/edit-catrgory.component';
import { BlogPostListComponent } from './Features/Blog-Post/blog-post-list/blog-post-list.component';
import { AddBlogpostComponent } from './Features/Blog-Post/add-blogpost/add-blogpost.component';
import { MarkdownModule } from 'ngx-markdown';
import { EditBlogPostComponent } from './Features/Blog-Post/edit-blog-post/edit-blog-post.component';
import { ImageSelectoreComponent } from './Sheard/Components/image-selectore/image-selectore.component';
import { HomeComponent } from './Features/Public/home/home.component';
import { BlogDteailsComponent } from './Features/Public/blog-dteails/blog-dteails.component';
import { LoginComponent } from './Features/auth/login/login.component';
import { AuthInterceptor } from './Core/Interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NvarbarComponent,
    CategoryListComponent,
    AddCategoryComponent,
    EditCatrgoryComponent,
    BlogPostListComponent,
    AddBlogpostComponent,
    EditBlogPostComponent,
    ImageSelectoreComponent,
    HomeComponent,
    BlogDteailsComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MarkdownModule.forRoot()
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:AuthInterceptor,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
