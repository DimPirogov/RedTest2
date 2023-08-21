import { Quote } from './quote';

export interface Book {
  id: number;
  date: Date;
  title: string;
  author: string;
  quote?: Quote[];
}
