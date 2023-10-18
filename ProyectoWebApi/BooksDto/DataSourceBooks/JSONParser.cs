using BooksData.Model;
using BooksDto.DataSourceBooks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BooksData.XML
{
    public class JSONParser<type> : JsonConfig
    {
        // Una funcion la hago con tipos genericos para mostrar su uso
        public List<type> serializeAddJSON(type book, string jsonName, string jsonListName)
        {
            try
            {
                string json = File.ReadAllText(base.pathJSON + jsonName);

                List<type> books = base.GetFile<type>(json, jsonListName);

                books.Add(book);

                // Serializar la lista actualizada de libros de nuevo a JSON
                var updatedJson = JsonSerializer.Serialize(new { books });

                // Escribir el JSON actualizado de nuevo en el archivo
                File.WriteAllText(this.pathJSON + jsonName, updatedJson);

                return books;

            }
            catch
            {
                throw;
            }

        }

        public List<BookModel> serializeRemoveJSON(string title)
        {
            try
            {
                string jsonBooks = File.ReadAllText(base.pathJSON + "books.json");

                List<BookModel> books = base.GetFile<BookModel>(jsonBooks, "books");

                // primero busco el libro en la lista, si existe lo borro sino lanzo exepcion
                if (!books.Any(b => string.Compare(b.title, title) == 0))
                    throw new Exception("El libro que desea eliminar no existe");

                books = books.Where(b => string.Compare(b.title, title, true) != 0).ToList();

                // Serializar la lista actualizada de libros de nuevo a JSON
                var updatedJson = JsonSerializer.Serialize(new { books });

                // Escribir el JSON actualizado de nuevo en el archivo
                File.WriteAllText(base.pathJSON + "books.json", updatedJson);

                return books;

            }
            catch
            {
                throw;
            }
        }

        // Aca tambien aplico una busqueda con tipos genericos
        public List<type> deserializeJSON(string listName, string jsonName)
        {
            try
            {
                string jsonBooks = File.ReadAllText(this.pathJSON + jsonName);

                List<type> books = base.GetFile<type>(jsonBooks, listName);

                return books.ToList();
            }
            catch
            {
                // Si entro aca es porque el archivo esta corrupto o no se pudo leer, entonces devuelvo una lista vacia
                return new List<type>();
            }
        }
    }
}
