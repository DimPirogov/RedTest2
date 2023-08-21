import { Book } from "./book";

export interface Quote {
  id: number;
  text: string;
  bookId: number;
  book: Book;
}
