import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Brand } from 'src/app/Model/Brand';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  url=environment.ApiUrl+"Brand/";
  brand:Brand[]=[];


  constructor(private _http:HttpClient) { }

  public GetAll(){
    if(this.brand.length>0) return of(this.brand);

    return this._http.get<Brand[]>(this.url+"GetAll").pipe(
      map(response=>{
        this.brand=response;
        return response;
      })
    )
  }
}
