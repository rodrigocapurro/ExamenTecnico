using BooksNetCoreDto.DataSourceBooksNetCore;
using BooksNetCoreDto.ModelNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksNetCoreDto.DtoNetCore
{
    public class BookNetCoreDto
    {
        private JSONParser<BookModelNetCore> _jsonBooks;

        public BookNetCoreDto()
        {
            this._jsonBooks = new JSONParser<BookModelNetCore>();
        }

        #region Seach(s) Method(s)

        /// <summary>
        /// Search All the books
        /// </summary>
        /// <returns>return books list with all attributes</returns>
        public List<BookModelNetCore> SearchAll()
        {
            try
            {
                return this._jsonBooks.deserializeJSON("books", "books.json").OrderBy(b => b.title).ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Search All Books that contains the parametter title 
        /// </summary>
        /// <param name="title">title the book to search</param>
        /// <returns>return books list with all attributes</returns>
        public List<BookModelNetCore> searchByTitle(string title, bool isContains)
        {
            try
            {
                var booksList = (isContains) ? this.SearchAll().Where(b => b.title.ToUpper().Contains(title.ToUpper())).ToList() :
                    this.SearchAll().Where(b => string.Compare(b.title, title, true) == 0).ToList();

                // Si no encuentra el libro, lanzo excepcion 
                if (booksList == null || booksList.Count() == 0)
                    throw new Exception("No se encuentra ningun libro con el titulo: " + title);

                return booksList;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Search All Books that contains the parametter author 
        /// </summary>
        /// <param name="author">author the book to search</param>
        /// <returns>return books list with all attributes</returns>
        public List<BookModelNetCore> searchByAuthor(string author)
        {
            try
            {
                var booksList = this.SearchAll().Where(b => b.author.ToUpper().Contains(author.ToUpper())).ToList();

                // Si no encuentra el libro, lanzo excepcion 
                if (booksList == null || booksList.Count() == 0)
                    throw new Exception("No se encuentran libros con el autor indicado");

                return booksList;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region AMB(s) Method(s)

        /// <summary>
        /// Add a book to list Json File
        /// </summary>
        /// <param name="book">book to be added</param>
        /// <returns>return the list updated</returns>
        public List<BookModelNetCore> AddBook(BookModelNetCore book)
        {
            try
            {
                return this._jsonBooks.serializeAddJSON(book, "books.json", "books");
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Remove a book of the list of Json File
        /// </summary>
        /// <param name="title">title the book to be deleted</param>
        /// <returns>return the list updated</returns>
        public List<BookModelNetCore> RemoveBook(string title)
        {
            try
            {
                return this._jsonBooks.serializeRemoveJSON(title, "books.json");

            }
            catch
            {
                throw;
            }

        }

        #endregion
    }
}
