using BooksNetCoreDto.ModelNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksNetCoreBusiness.Interfaces
{
    public interface IBookBusNetCore
    {
        #region Seach(s) Method(s) 

        List<BookModelNetCore> SearchAll();

        List<BookModelNetCore> searchByTitle(string title, bool isContains);

        List<BookModelNetCore> searchByAuthor(string author);

        #endregion

        #region AMB(s) Method(s) Validation(s)

        List<BookModelNetCore> AddBook(BookModelNetCore book);

        List<BookModelNetCore> RemoveBook(string title);

        #endregion
    }
}
