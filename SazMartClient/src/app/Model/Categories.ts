import { SubCategoriesDTO } from "./SubCategoriesDTO";

export interface categories{
     id:number;
     categoriesName:string;
     subCategories:string;
     description:string;
     subCategoriesDTO:SubCategoriesDTO[]
       
}