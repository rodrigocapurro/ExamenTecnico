using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksApi.Response
{
    public abstract class BaseResponse
    {
        public int cod_Http { get; set; }

        public string status { get; set; }

        public string mensaje { get; set; }
    }
}