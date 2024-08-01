import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../Models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = `http://localhost:60547/api`; 

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl + '/Book')
  }

  getBook(id: number): Observable<Book> {
    return this.http.get<Book>(this.apiUrl + '/book' + id)
  }
}
