import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Book } from '../model/book';
import { Quote } from '../model/quote';
import { AddBookDTO } from '../model/addBookDTO';
import { UpdateBookDTO } from '../model/updateBookDTO';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  books: Book[] = [];
  quotes: Quote[] = [];
  URL = 'https://localhost:7053/api/Book';

  constructor(private http: HttpClient) {
    this.getBooks();
  }
  getBooks() {
    return this.http.get<Book[]>(this.URL + '/GetAllBooks');
  }
  getBook(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.URL}/GetBook/${id}`);
  }
  updateBook(id: number, book: UpdateBookDTO): Observable<Book> {
    return this.http.put<Book>(`${this.URL}/UpdateBook/${id}`, book);
  }
  addBook(book: AddBookDTO): Observable<Book> {
    return this.http.post<Book>(`${this.URL}/AddBook`, book);
  }
  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.URL}/DeleteBook/${id}`);
  }
  // quotes section
  getBookQuotes(bokId: number): Observable<Quote[]> {
    return this.http.get<Quote[]>(`${this.URL}/GetBook/${bokId}/quotes`);
  }
  addBookQuote(bokId: number, quote: string): Observable<string> {
    return this.http.post<string>(`${this.URL}/AddBook/${bokId}/quotes`, quote);
  }
  deleteBookQuote(quoteId: number): Observable<void> {
    return this.http.delete<void>(`${this.URL}/DeleteQuote/${quoteId}`);
  }
}
