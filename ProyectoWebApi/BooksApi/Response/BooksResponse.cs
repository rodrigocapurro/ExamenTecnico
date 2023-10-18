using BooksData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksApi.Response
{
    public class BooksResponse: BaseResponse
    {
        public List<BookModel> booksList { get; set; }
    }
}