import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SearchBookComponent} from './Components/search-book/search-book.component'

const routes: Routes = [
  { path: '', component: SearchBookComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
