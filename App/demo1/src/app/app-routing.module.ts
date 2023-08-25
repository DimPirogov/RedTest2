import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BooklistComponent } from './booklist/booklist.component';
import { EditBookComponent } from './edit-book/edit-book.component';
import { NewBookComponent } from './new-book/new-book.component';
import { LoginComponent } from './login/login.component';
import { QuoteslistComponent } from './quoteslist/quoteslist.component';
import { NewQuoteComponent } from './new-quote/new-quote.component';

const routes: Routes = [
  { path: '', redirectTo: '/booklist', pathMatch: 'full'},
  { path: 'booklist', component: BooklistComponent },
  { path: 'edit-book/:id', component: EditBookComponent },
  { path: 'new-book', component: NewBookComponent },
  { path: 'login', component: LoginComponent },
  { path: 'quoteslist/:id', component: QuoteslistComponent},
  { path: 'new-quote/:id', component: NewQuoteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
