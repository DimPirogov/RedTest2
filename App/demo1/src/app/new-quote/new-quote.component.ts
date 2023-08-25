import { Location } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { BookService } from '../services/book.service';
import { AddQuoteDTO } from '../model/addQuoteDTO';

@Component({
  selector: 'app-new-quote',
  templateUrl: './new-quote.component.html',
  styleUrls: ['./new-quote.component.css']
})

export class NewQuoteComponent {
  constructor(
    private bookService: BookService,
    private location: Location,
    private route: ActivatedRoute
  ) {}
  addQuote(newQuote: NgForm) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    const quote = newQuote.value as AddQuoteDTO;
    quote.bookId = id;
    console.log(quote);
    this.bookService.addBookQuote(quote).subscribe(() => this.goBack());
  }
  goBack(): void {
    this.location.back();
  }
}
