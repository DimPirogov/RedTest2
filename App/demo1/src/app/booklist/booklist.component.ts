import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';

import { Book } from '../model/book';
import { Quote } from '../model/quote';
import { BookService } from '../services/book.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.css'],
})
export class BooklistComponent implements OnInit {
  isLoggedIn$: Observable<boolean> | undefined;
  books: Book[] = [];

  constructor(private bookService: BookService,
              private userService: UserService) {}

  ngOnInit(): void {
    this.isLoggedIn$ = this.userService.isLoggedIn;
    this.getBooks();
  }
  getBooks(): void {
    this.bookService
      .getBooks()
      .pipe(take(1))
      .subscribe((books) => ((this.books = books), console.log(this.books)));
  }
  deleteBook(id: number) {
    this.bookService.deleteBook(id)
      .pipe(take(1))
      .subscribe(() => {this.books = this.books.filter((dltBook) => dltBook.id !== id)})
  };
}
