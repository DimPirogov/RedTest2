import { Component } from '@angular/core';
import { take } from 'rxjs';

import { Book } from '../model/book';
import { Quote } from '../model/quote';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.css'],
})
export class BooklistComponent {
  books: Book[] = [];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.getBooks();
  }
  getBooks(): void {
    this.bookService
      .getBooks()
      .pipe(take(1))
      .subscribe((books) => ((this.books = books), console.log(this.books)));
  }
  deleteBook(id: number): void {
    this.bookService
      .deleteBook(id)
      .pipe(take(1))
      .subscribe(() => {
        this.books.filter((dltBook) => dltBook.id !== id);
      });
  }
}
