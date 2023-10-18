using BooksData.Model;
using BooksData.XML;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BooksData.Dto
{
    public class BookDto
    {
        private JSONParser<BookModel> _jsonBooks;

        public BookDto()
        {
            this._jsonBooks = new JSONParser<BookModel>();
        }

        #region Seach(s) Method(s)

        /// <summary>
        /// Search All the books
        /// </summary>
        /// <returns>return books list with all attributes</returns>
        public List<BookModel> SearchAll()
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
        public List<BookModel> searchByTitle(string title, bool isContains)
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
        public List<BookModel> searchByAuthor(string author)
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
        public List<BookModel> AddBook(BookModel book)
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
        public List<BookModel> RemoveBook(string title)
        {
            try
            {
                return this._jsonBooks.serializeRemoveJSON(title);

            }
            catch
            {
                throw;
            }

        }

        #endregion
    }
}
