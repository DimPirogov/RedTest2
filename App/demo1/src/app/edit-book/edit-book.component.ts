import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { UpdateBookDTO } from '../model/updateBookDTO';
import { BookService } from '../services/book.service';
import { Book } from '../model/book';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css'],
})
export class EditBookComponent {
  updateBookDTO: UpdateBookDTO | undefined;
  book: Book | undefined;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.getBook();
  }

  getBook(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.bookService.getBook(id).subscribe((book) => (this.book = book));
  }

  save(): void {
    if (this.book) {
      this.updateBookDTO = this.book;
      this.bookService
        .updateBook(this.book.id, this.updateBookDTO)
        .subscribe(() => this.goBack());
    } else this.goBack();
  }

  goBack(): void {
    this.location.back();
  }
}
