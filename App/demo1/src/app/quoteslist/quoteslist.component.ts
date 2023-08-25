import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Book } from '../model/book';
import { Quote } from '../model/quote';
import { BookService } from '../services/book.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-quoteslist',
  templateUrl: './quoteslist.component.html',
  styleUrls: ['./quoteslist.component.css']
})

export class QuoteslistComponent implements OnInit{
  isLoggedIn$: Observable<boolean> | undefined;
  quotes: Quote[] = [];
  bookId: number | undefined;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private bookService: BookService,
    private userService: UserService) {}

  ngOnInit(): void {
    this.isLoggedIn$ = this.userService.isLoggedIn;
    this.getQuotes();
  }

  getQuotes(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.bookService.getBookQuotes(id)
      .pipe(take(1))
      .subscribe((quotes) => ((this.quotes = quotes), console.log(this.quotes), this.bookId = id));
  }
  deleteQuote(id: number) {
    this.bookService.deleteBookQuote(id)
      .pipe(take(1))
      .subscribe(() => {this.quotes = this.quotes.filter((dltQuote) => dltQuote.id !== id)})
  }

  goBack(): void {
    this.location.back();
  }
}
