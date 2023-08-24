import { NgForm } from '@angular/forms';
import { Component, NgModule } from '@angular/core';
import { Location } from '@angular/common';

import { AddBookDTO } from '../model/addBookDTO';
import { BookService } from '../services/book.service';
import { Book } from '../model/book';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css'],
})
export class NewBookComponent {
  constructor(private bookService: BookService, private location: Location) {}
  addBook(newBook: NgForm) {
    const book = newBook.value as AddBookDTO;
    this.bookService.addBook(book).subscribe(() => this.goBack());
  }
  goBack(): void {
    this.location.back();
  }
}
