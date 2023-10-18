using BooksApi.Response;
using BooksData.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BooksBusiness.BooksValidations;
using BooksBusiness.Interfaces;

namespace BooksApi.Controllers
{ 
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private ILog log = LogManager.GetLogger(typeof(BooksController));

        private IBookBus iBookBus;

        public BooksController()
        {
        }

        public BooksController(IBookBus ibookBus): this()
        {
            this.iBookBus = ibookBus;
        }

        #region Read(s) Api(s)

        [HttpGet]
        [Route("GetAll")]
        public BooksResponse GetAllBooks()
        {
            try
            {
                var listBooks = this.iBookBus.SearchAll();

                this.log.Info("La busqueda de libros fue exitosa");

                return new BooksResponse()
                {
                    cod_Http = 200,
                    status = "OK",
                    mensaje = "Success",
                    booksList = listBooks
                };

            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);

                return new BooksResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]
        public BooksResponse GetByTitle(string title)
        {
            try
            {
                var listBooks = this.iBookBus.searchByTitle(title, true);

                return new BooksResponse()
                {
                    cod_Http = 200,
                    status = "OK",
                    mensaje = "Success",
                    booksList = listBooks
                };
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return new BooksResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetByAuthor/{author}")]
        public BooksResponse GetByAuthor(string author)
        {
            try
            {
                var listBooks = this.iBookBus.searchByAuthor(author);

                return new BooksResponse()
                {
                    cod_Http = 200,
                    status = "OK",
                    mensaje = "Success",
                    booksList = listBooks
                };
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return new BooksResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        #endregion

        #region Write(s) Api(s)

        [HttpPost]
        [Route("AddBook")]
        public BooksResponse AddBook(BookModel book)
        {
            try
            {
                var listBooksUpdated = this.iBookBus.AddBook(book);

                this.log.Info(string.Format("Libro {0} agredo correctamente", book.title));

                return new BooksResponse()
                {
                    cod_Http = 200,
                    status = "OK",
                    mensaje = "Book added succesfully",
                    booksList = listBooksUpdated
                };
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);

                return new BooksResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("RemoveBook/{title}")]
        public BooksResponse RemoveBook(string title)
        {
            try
            {
                var listBooksUpdated = this.iBookBus.RemoveBook(title);

                this.log.Info(string.Format("Libro {0} elminado correctamente", title));

                return new BooksResponse()
                {
                    cod_Http = 200,
                    status = "OK",
                    mensaje = "Book deleted succesfully",
                    booksList = listBooksUpdated
                };
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);

                return new BooksResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        #endregion

    }
}
