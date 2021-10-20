import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandlistComponent } from './Module/Admin/Brand/List Brand/brandlist/brandlist.component';
import { AdminNavBarComponent } from './Module/Admin/Nav-bar/admin-nav-bar/admin-nav-bar.component';
import { NavBarComponent } from './Module/Nav-Bar/nav-bar/nav-bar.component';

const routes: Routes = [
  {path:'', component:NavBarComponent},
  {path:'admin', component:AdminNavBarComponent},
  {path:'Brand',
  children:[
    {path:'BrandList' , component:BrandlistComponent}

  ]

}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
