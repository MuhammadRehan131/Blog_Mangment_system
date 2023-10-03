import { Category } from "../../Category/Models/Category.model";

export interface BlogPost{
    id:string;
    title:string;
    discription:string;
    content:string;
    featureImaheUrl:string;
    urlHandle:string;
    author:string;
    publishedDate:Date;
    isVisable:boolean;
    categories:Category[];
}