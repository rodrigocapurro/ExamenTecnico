import { Component } from '@angular/core';
import { SearchBooksService } from '../../Services/search-books.service'
import { Book } from 'src/app/Model/book';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-search-book',
  templateUrl: './search-book.component.html',
  styleUrls: ['./search-book.component.css']
})
export class SearchBookComponent {

  // variables para busqueda de libros
  books: Book[] = [];
  booksFilterSearch:Book[]=[];
  booksByTitle: Book[] = [];
  booksByAuthor: Book[] = [];
  loading: boolean = true;

  constructor(private searchBookService: SearchBooksService) {}

    async ngOnInit() {
      
      // Busco todos los libros al cargar la pagina
      try {
        const data = await this.searchBookService.getBooksAll();
        if (data) {
          this.books = data?.booksList ?? [];
          this.booksFilterSearch = this.books
          this.loading = false;
        }
      } catch (error) {
        console.error('Error al obtener los libros:', error);
        this.loading = false;
        this.books = []
      }
  }
}
