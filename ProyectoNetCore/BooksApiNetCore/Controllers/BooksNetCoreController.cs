using BooksApiNetCore.Response;
using BooksNetCoreBusiness.BooksValidationsNetCore;
using BooksNetCoreBusiness.Interfaces;
using BooksNetCoreDto.ModelNetCore;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BooksApiNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksNetCoreController : ControllerBase
    {
        private readonly ILogger<BooksNetCoreController> _logger;
        private readonly IBookBusNetCore _iBookBusNetCore;

        public BooksNetCoreController(ILogger<BooksNetCoreController> logger, IBookBusNetCore ibookNetCore)
        {
            _logger = logger;
            this._iBookBusNetCore = ibookNetCore;
        }

        private ILog log = LogManager.GetLogger(typeof(BooksNetCoreController));


        #region Read(s) Api(s)

        [HttpGet]
        [Route("GetAll")]
        public BooksNetCoreResponse GetAllBooks()
        {
            try
            {
                var listBooks = this._iBookBusNetCore.SearchAll();

                this.log.Info("La busqueda de libros fue exitosa");

                return new BooksNetCoreResponse()
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

                return new BooksNetCoreResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]
        public BooksNetCoreResponse GetByTitle(string title)
        {
            try
            {
                var listBooks = this._iBookBusNetCore.searchByTitle (title, true);

                return new BooksNetCoreResponse()
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
                return new BooksNetCoreResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetByAuthor/{author}")]
        public BooksNetCoreResponse GetByAuthor(string author)
        {
            try
            {
                var listBooks = this._iBookBusNetCore.searchByAuthor(author);

                return new BooksNetCoreResponse()
                {
                    cod_Http = 200,
                    status = "OK",
                    mensaje = "Success",
                    booksList = listBooks
                };
            }
            catch (Exception ex)
            {
                //this.log.Error(ex.Message);
                return new BooksNetCoreResponse()
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
        public BooksNetCoreResponse AddBook(BookModelNetCore book)
        {
            try
            {
                var listBooksUpdated = this._iBookBusNetCore.AddBook(book);

                return new BooksNetCoreResponse()
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

                return new BooksNetCoreResponse()
                {
                    cod_Http = 500,
                    status = "Internal Server Error 500",
                    mensaje = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("RemoveBook/{title}")]
        public BooksNetCoreResponse RemoveBook(string title)
        {
            try
            {
                var listBooksUpdated = this._iBookBusNetCore.RemoveBook(title);

                return new BooksNetCoreResponse()
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

                return new BooksNetCoreResponse()
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