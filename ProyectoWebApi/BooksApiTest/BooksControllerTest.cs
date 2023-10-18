using BooksApi.Controllers;
using BooksBusiness.BooksValidations;
using BooksBusiness.Interfaces;
using BooksData.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Web.Http.Results;

namespace BooksApiTest
{
    [TestClass]
    public class BooksControllerTest
    {
        private BooksController controller;

        public BooksControllerTest(IBookBus ibookBus)
        {
            this.controller = new BooksController(ibookBus);
        }

        [TestMethod]
        public void TestGetAllBooks()
        {
            try
            {
                var result = this.controller.GetAllBooks();

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                System.Diagnostics.Debug.WriteLine(result.mensaje);
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(result.booksList));

                Assert.AreEqual(200, result.cod_Http);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestGetByTitle()
        {
            try
            {
                var result = this.controller.GetByTitle("El principito");

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                System.Diagnostics.Debug.WriteLine(result.mensaje);
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(result.booksList));
                Assert.AreEqual(200, result.cod_Http);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestGetByAuthor()
        {
            try
            {
                var result = this.controller.GetByAuthor("Lewis");

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                System.Diagnostics.Debug.WriteLine(result.mensaje);
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(result.booksList));

                Assert.AreEqual(200, result.cod_Http);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestAddBookSuccessfully()
        {
            try
            {
                // Creo un book
                var book = new BookModel()
                {
                    title = "Divina Comedia 2",
                    author = "Daniel Alighieri",
                    publicationYear = 1950,
                    isbn = "234-2343423545"
                };

                var result = this.controller.AddBook(book);

                System.Diagnostics.Debug.WriteLine(result.mensaje);

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                Assert.AreEqual(200, result.cod_Http);

                // si llego hasta aca es porque el libro se agrego bien, entonces muestro la lista
                // actualizada de los libros
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(result.booksList));
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestAddBookWithoutTitle()
        {
            try
            {
                // Creo un book sin titulo
                var book = new BookModel()
                {
                    author = "Daniel Alighieri",
                    publicationYear = 1950,
                    isbn = "234-2343423545"
                };

                var result = this.controller.AddBook(book);

                System.Diagnostics.Debug.WriteLine(result.mensaje);

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                Assert.AreEqual(500, result.cod_Http);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestAddBookWithoutAuthor()
        {
            try
            {
                // Creo un book
                var book = new BookModel()
                {
                    title = "Divina Comedia",
                    publicationYear = 1950,
                    isbn = "234-2343423545"
                };

                var result = this.controller.AddBook(book);

                System.Diagnostics.Debug.WriteLine(result.mensaje);

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                Assert.AreEqual(500, result.cod_Http);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestAddBookWithoutPublicatiorYear()
        {
            try
            {

                // Creo un book
                var book = new BookModel()
                {
                    title = "Divina Comedia",
                    author = "Daniel Alighieri",
                    isbn = "234-2343423545"
                };

                var result = this.controller.AddBook(book);

                System.Diagnostics.Debug.WriteLine(result.mensaje);

                // Assert: verifica el resultado de la acción.
                Assert.IsNotNull(result);

                Assert.AreEqual(500, result.cod_Http);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

    }
}
