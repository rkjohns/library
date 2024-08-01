export interface Book {
  id: number;
  title: string;
  description: string;
  author: string;
  coverImageUrl: string;
  publisher: string;
  publicationDate: Date;
  category: string;
  isbn: number;
  pagecount: number;
  isDeleted: boolean;
}
