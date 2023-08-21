import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BooklistComponent } from './booklist/booklist.component';

const routes: Routes = [
  { path: '', redirectTo: '/booklist', pathMatch: 'full'},
  { path: 'booklist', component: BooklistComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
