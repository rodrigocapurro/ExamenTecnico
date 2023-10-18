using BooksNetCoreBusiness.Interfaces;
using BooksNetCoreDto.DtoNetCore;
using BooksNetCoreDto.ModelNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksNetCoreBusiness.BooksValidationsNetCore
{
    public class BookBusNetCore: IBookBusNetCore
    {
        private BookNetCoreDto _bookDto;

        public BookBusNetCore()
        {
            this._bookDto = new BookNetCoreDto();
        }

        #region Seach(s) Method(s) 

        public List<BookModelNetCore> SearchAll()
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

        public List<BookModelNetCore> searchByTitle(string title, bool isContains)
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

        public List<BookModelNetCore> searchByAuthor(string author)
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

        public List<BookModelNetCore> AddBook(BookModelNetCore book)
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

        public List<BookModelNetCore> RemoveBook(string title)
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
        private string bookIsValid(BookModelNetCore book)
        {
            if (string.IsNullOrEmpty(book.title))
                return "El titulo del libro no puede ser vacio";
            else if (string.IsNullOrEmpty(book.author))
                return "El autor del libro no puede ser vacio";
            else if (book.publicationYear == 0)
                return "Debe ingresar la fecha de publicacion";
            else
                return string.Empty;
        }

        #endregion
    }
}
