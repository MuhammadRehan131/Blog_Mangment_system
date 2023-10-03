import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './Features/Category/category-list/category-list.component';
import { AddCategoryComponent } from './Features/Category/add-category/add-category.component';
import { EditCatrgoryComponent } from './Features/Category/edit-catrgory/edit-catrgory.component';
import { BlogPostListComponent } from './Features/Blog-Post/blog-post-list/blog-post-list.component';
import { AddBlogpostComponent } from './Features/Blog-Post/add-blogpost/add-blogpost.component';
import { EditBlogPostComponent } from './Features/Blog-Post/edit-blog-post/edit-blog-post.component';
import { HomeComponent } from './Features/Public/home/home.component';
import { BlogDteailsComponent } from './Features/Public/blog-dteails/blog-dteails.component';
import { LoginComponent } from './Features/auth/login/login.component';
import { authGuard } from './Features/auth/guards/auth.guard';

const routes: Routes = [

  {
    path:'',
    component:HomeComponent
  },
  {
    path:'admin/home',
    component:HomeComponent
  },
   
  {
    path:'login',
    component:LoginComponent
  },
  
  {
    path:'blog/:url',
    component:BlogDteailsComponent
  },
  {
    path:'admin/category',
    component:CategoryListComponent,
    canActivate:[authGuard]
  },
  {
    path:'admin/category/add',
    component:AddCategoryComponent,
    canActivate:[authGuard]
  },
  {
    path:'admin/category/:id',
    component:EditCatrgoryComponent,
    canActivate:[authGuard]
  },
  {
    path:'admin/BlogPost',
    component:BlogPostListComponent 
  },
  {
    path:'admin/BlogPost/add',
    component:AddBlogpostComponent,
    canActivate:[authGuard]
  },
  {
    path:'admin/BlogPost/:id',
    component:EditBlogPostComponent,
    canActivate:[authGuard]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
