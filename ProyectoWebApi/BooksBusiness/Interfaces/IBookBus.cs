using BooksData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBusiness.Interfaces
{
    public interface IBookBus
    {
        #region Seach(s) Method(s) 

        List<BookModel> SearchAll();

        List<BookModel> searchByTitle(string title, bool isContains);

        List<BookModel> searchByAuthor(string author);

        #endregion

        #region AMB(s) Method(s) Validation(s)

        List<BookModel> AddBook(BookModel book);

        List<BookModel> RemoveBook(string title);

        #endregion
    }
}
