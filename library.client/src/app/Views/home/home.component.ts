import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { Book } from '../../Shared/Models/book';
import { BookService } from '../../Shared/Services/book.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  
  bookcollection: Book[] = [];
  dataSource: Book[] = [];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.bookService.getBooks().subscribe(
      (data) => { this.bookcollection = data; },
      (error) => { console.error('Failed to fetch books', error) })

    this.bookcollection = this.dataSource;
  }

}
