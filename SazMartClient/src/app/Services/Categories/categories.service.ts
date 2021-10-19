import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { categories } from 'src/app/Model/Categories';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  url=environment.ApiUrl+"Categories/";
  categories:categories[]=[];

  constructor(private _http:HttpClient) { }


  public GetAll(){
    if(this.categories.length>0) return of(this.categories);
    return this._http.get<categories[]>(this.url+"GetAll").pipe(
      map(response=>{
        this.categories=response;
        return response;
      })
    )
  }
}
