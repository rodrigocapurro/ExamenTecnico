import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book , BooksResponse} from '../Model/book'
import { environment } from '../../Environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchBooksService {

  private apiUrl = environment.apiNetCoreURL;

  constructor(private http: HttpClient) {}

  async getBooksAll(): Promise<BooksResponse  | undefined> {
    try {
      const data = await this.http.get<BooksResponse>(`${this.apiUrl}/GetAll`).toPromise();
      return data;
    } catch (error) {
      console.error('Error al obtener los libros:', error);
      throw error;
    }
  }

  async getBooksByTitle(title:string): Promise<BooksResponse  | undefined> {
    try {
      const data = await this.http.get<BooksResponse>(`${this.apiUrl}/GetByTitle/${title}`).toPromise();
      return data;
    } catch (error) {
      console.error('Error al obtener los libros con el titulo: ' + title, error);
      throw error;
    }
  }

  async getBooksByAuthor(author:string): Promise<BooksResponse  | undefined> {
    try {
      const data = await this.http.get<BooksResponse>(`${this.apiUrl}/GetByAuthor/${author}`).toPromise();
      return data;
    } catch (error) {
      console.error('Error al obtener los libros con el autor: ' + author, error);
      throw error;
    }
  }

  async removeBook(title:string): Promise<BooksResponse  | undefined> {
    try {
      const data = await this.http.get<BooksResponse>(`${this.apiUrl}/RemoveBook/${title}`).toPromise();
      return data;
    } catch (error) {
      console.error('Error al eliminar el libro: ' + title, error);
      throw error;
    }
  }

  async addBook(newBook:Book):Promise<BooksResponse  | undefined> {
    try {
      const data = await this.http.post<BooksResponse>(`${this.apiUrl}/AddBook`,newBook).toPromise();
      return data;
    } catch (error) {
      console.error('Error al crear el libro: ' + newBook.title, error);
      throw error;
    }
  }
}
