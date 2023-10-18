import { Component, Input } from '@angular/core';
import { Book } from 'src/app/Model/book';
import { SearchBooksService } from '../../../Services/search-books.service'

@Component({
  selector: 'app-table-filtered',
  templateUrl: './table-filtered.component.html',
  styleUrls: ['./table-filtered.component.css']
})
export class TableFilteredComponent {

  @Input() books: Book[] = [];
  @Input() booksFilterSearch:Book[]=[];
  @Input() loading: boolean = true;

  @Input() booksByTitle: Book[] = [];
  @Input() booksByAuthor: Book[] = [];
  @Input() isFilterSeach: boolean = false;
  @Input() addNew: boolean=false;
  @Input() placeHolder: string=''
  @Input() isFilter: boolean=false
  @Input() isTitle: boolean=false
  searchTitleBookModel: string= '';
  searchAuthorBookModel: string= '';
  displayModalConfirmation: boolean= false;
  messageModalConfirmation:string='';
  titleSelected:string=''
  displayModal: boolean= false;
  messageModal: string= '';

  modalAddBook: boolean=false;
  valueSearch:string=''
  
   // Variables para creacion de libros
   newBook: Book={};
  
constructor(private searchBookService: SearchBooksService) { }

showConfirmation(title:string){
    this.messageModalConfirmation = "¿Esta seguro que desea eliminar el libro seleccionado?"
    this.titleSelected = title;
    this.displayModalConfirmation= true;
  }

  async confirmDelete()
  {
    try
    {
      var typeList = this.isFilter ? 'books' : (this.isTitle ? 'booksByTitle': 'booksByAuthor')

      var result = await this.deleteBook(this.titleSelected, typeList)
      console.log(result)
      this.displayModalConfirmation =false;
      this.messageModalConfirmation = ''
    }
    catch(error)
    {
      console.log(error)
    }
  }

  // Elmino un libro de la grilla
  async deleteBook(title:string, typeListUpdated:string)
  {
    try {
      this.displayModalConfirmation = false;
      this.loading= true;
      const data = await this.searchBookService.removeBook(title);
      console.log('data', data)
      if (data) {

        if(data?.cod_Http == 200)
        {
          switch(typeListUpdated)
          {
            case 'books':
              this.booksFilterSearch = data?.booksList ?? []
              break;
            case 'booksByTitle':
              // Llamo a esta funcion para actualiza la grilla sin perder el filtro ingresado
              this.searchByFilterButtonClick()
              break;
            case 'booksByAuthor':
              // Llamo a esta funcion para actualiza la grilla sin perder el filtro ingresado
              this.searchByFilterButtonClick()
              break;
            default:
              break;
          }
        }
        this.loading = false;
        this.messageModal = data?.mensaje ?? ''
        this.displayModal = true
      }

      return data

    } catch (error) {
      console.error('Error al eliminar el libro:', title);
      this.loading = false;
      this.messageModal = "Hubo un error al elminar el libro"
      this.displayModal = true
      return null
    }
  }

  AddNew()
  {
    this.modalAddBook = true;
  }

  filterSearch(valueSearch: string ) {
    if(this.isFilterSeach)
    {
      this.booksFilterSearch = this.books.filter((elemento:Book) => {
        // Aplica el filtro a los campos específicos
        return (
          (elemento.title?.toLowerCase().includes(valueSearch.toLowerCase()) ||
            elemento.author?.toLowerCase().includes(valueSearch.toLowerCase()) ||
            elemento.publicationYear?.toString().includes(valueSearch) ||
            elemento.isbn?.toLowerCase().includes(valueSearch.toLowerCase()))
        );
      });
    }
  }

   // Busco los libros filtrando por titulo al clickear el boton de busqueda
   async searchByFilterButtonClick(){
    if(this.isTitle)
    {
      if(this.valueSearch == '' || this.valueSearch == undefined)
      {
        this.messageModal = "Debe ingresar un titulo";
        this.displayModal = true
      }
      else
      {
        try {
          this.loading= true;
          const data = await this.searchBookService.getBooksByTitle(this.valueSearch);
          console.log('data', data)
          if (data) {
            this.booksByTitle = data?.booksList ?? [];
            this.loading = false;
            if(this.booksByTitle.length ==0)
            {
              this.messageModal = data?.mensaje ?? 'No se encuentran Libros con los filtros indicados'
              this.displayModal = true
            }
          }
        } catch (error) {
          console.error('Error al obtener los libros:', error);
          this.loading = false;
          this.booksByTitle = []
        }
      }
    }
    else
    {
      if(this.valueSearch == '' || this.valueSearch == undefined)
      {
        this.messageModal = "Debe ingresar un autor";
        this.displayModal = true
      }
      else
      {
        try {
          this.loading= true;
          const data = await this.searchBookService.getBooksByAuthor(this.valueSearch);
          console.log('data', data)
          if (data) {
            this.booksByAuthor = data?.booksList ?? [];
            this.loading = false;
            if(this.booksByTitle.length ==0)
            {
              this.messageModal = data?.mensaje ?? 'No se encuentran Libros con los filtros indicados'
              this.displayModal = true
            }
          }
        } catch (error) {
          console.error('Error al obtener los libros:', error);
          this.loading = false;
          this.booksByAuthor = []
        }
      }
    }
  }

  async confirmCreate()
  {

    try {
      this.loading= true;
      const data = await this.searchBookService.addBook(this.newBook);
      console.log('data', data)
      if (data) {
        this.loading = false;
        if(data?.cod_Http == 200)
        {
          this.booksFilterSearch = data?.booksList ?? [];
          this.modalAddBook = false;
        }
        console.log(data?.cod_Http)
        this.messageModal = data?.mensaje ?? ''
        this.displayModal = true
      }
    } catch (error) {
      console.error('Error al obtener los libros:', error);
      this.loading = false;
      this.booksByAuthor= []
    }

  }
}
