import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { categories } from 'src/app/Model/Categories';
import { CategoriesService } from 'src/app/Services/Categories/categories.service';

@Component({
  selector: 'app-listcategories',
  templateUrl: './listcategories.component.html',
  styleUrls: ['./listcategories.component.css']
})
export class ListcategoriesComponent implements OnInit {

  listcategories:Observable<categories[]> | undefined;

  constructor(private _categories:CategoriesService) { }

  ngOnInit(): void {
    this.listcategories=this._categories.GetAll();
  }

}
