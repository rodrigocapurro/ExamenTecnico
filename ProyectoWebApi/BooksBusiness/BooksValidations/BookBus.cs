using BooksBusiness.Interfaces;
using BooksData.Dto;
using BooksData.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBusiness.BooksValidations
{
    public class BookBus: IBookBus
    {
        private BookDto _bookDto;

        public BookBus()
        {
            this._bookDto = new BookDto();
        }

        #region Seach(s) Method(s) 

        public List<BookModel> SearchAll()
        {
            try
            {
                return this._bookDto.SearchAll();
            }
            catch
            {
                throw;
            }
        }

        public List<BookModel> searchByTitle(string title, bool isContains)
        {
            try
            {
                return this._bookDto.searchByTitle(title, isContains);
            }
            catch
            {
                throw;
            }
        }

        public List<BookModel> searchByAuthor(string author)
        {
            try
            {
                return this._bookDto.searchByAuthor(author);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region AMB(s) Method(s) Validation(s)

        public List<BookModel> AddBook(BookModel book)
        {
            try
            {
                bool isExists = false;

                // Valido los datos del libro
                var validBook = this.bookIsValid(book);

                if (!string.IsNullOrEmpty(validBook))
                    throw new Exception(validBook);

                // Valido que el libro no exista, lo agrego en un try catch porque si no existe lanza excepcion
                try
                {
                    var searcBook = this.searchByTitle(book.title, false);
                    // si llego hasta aca es porq el libro existe entonces seteo la variable en true
                    isExists = true;
                }
                catch
                {
                    // Si entro aca es por el libro no existe, entonce la variable isExists queda en false
                }

                if (!isExists) // Si el libro no existe, lo agrego
                    return this._bookDto.AddBook(book);
                else
                    throw new Exception(string.Format("El libro con el titulo: {0}, ya existe", book.title));
            }
            catch
            {
                throw;
            }
        }

        public List<BookModel> RemoveBook(string title)
        {
            try
            {
                // Busco el libro que se va a borrar
                var book = this.searchByTitle(title, false);

                // si llegue hasta aca es porque el libro existe, caso contrario, la funcion searchByTitle
                // lanza excepcion en una capa mas arriba si no existe el libro
                return this._bookDto.RemoveBook(book.FirstOrDefault().title);

            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region Private(s) Method(s)

        /// <summary>
        /// Valid that the book not contains a empty or null field
        /// </summary>
        /// <param name="book"></param>
        /// <returns>return the string with error descript</returns>
        private string bookIsValid(BookModel book)
        {
            if (string.IsNullOrEmpty(book.title))
                return "El titulo del libro no puede ser vacio";
            else if (string.IsNullOrEmpty(book.author))
                return "El autor del libro no puede ser vacio";
            else if (book.publicationYear == 0)
                return "Debe ingresar el año de publicacion";
            else if (book.publicationYear > DateTime.Now.Year)
                return "El año de publicacion no puede ser mayor al año actual";
            else
                return string.Empty;
        }

        #endregion
    }
}
