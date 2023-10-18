import { TestBed, getTestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController  } from '@angular/common/http/testing';
import { SearchBooksService } from './search-books.service';
import { BooksResponse } from '../Model/book';

describe('SearchBooksService', () => {
  let injector: TestBed;
  let httpMock: HttpTestingController
  let service: SearchBooksService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [SearchBooksService],
    });
    injector = getTestBed();
    httpMock = injector.inject(HttpTestingController);
    service = TestBed.inject(SearchBooksService);
  });

  afterEach(() => {
    // Verifica que no haya solicitudes pendientes después de cada prueba
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve books from the API via GET', () => {
    const dummyBooks: BooksResponse = {
      cod_Http: 200, // Código HTTP de éxito
      mensaje: 'Éxito en la obtención de libros',
      booksList: [
        { title: 'El principito', author: 'Autor 1', publicationYear: 2020, isbn: 'ISBN-1' },
        { title: 'Libro 2', author: 'Autor 2', publicationYear: 2019, isbn: 'ISBN-2' },
      ]
    };

    const req = httpMock.expectOne(`${service['apiUrl']}/GetAll`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyBooks);

    service.getBooksAll().then((books) => {
      expect(books).toEqual(dummyBooks);
      console.log(books)
    });
  });
});
