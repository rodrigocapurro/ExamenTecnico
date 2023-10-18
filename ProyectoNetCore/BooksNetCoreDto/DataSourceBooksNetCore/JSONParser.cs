using BooksNetCoreDto.Configuration;
using BooksNetCoreDto.ModelNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BooksNetCoreDto.DataSourceBooksNetCore
{
    public class JSONParser<type>
    {
        private readonly string pathJSON = ConfigurationManagerJson.GetPathJsonFile();

        // Una funcion la hago con tipos genericos para mostrar su uso
        public List<type> serializeAddJSON(type book, string jsonName, string jsonListName)
        {
            try
            {
                string json = File.ReadAllText(this.pathJSON + jsonName);

                var dictionaryBooks = JsonSerializer.Deserialize<Dictionary<string, List<type>>>(json);

                if (dictionaryBooks != null)
                {
                    List<type> books = dictionaryBooks[jsonListName];

                    books.Add(book);

                    // Serializar la lista actualizada de libros de nuevo a JSON
                    var updatedJson = JsonSerializer.Serialize(new { books });

                    // Escribir el JSON actualizado de nuevo en el archivo
                    File.WriteAllText(this.pathJSON + jsonName, updatedJson);

                    return books;
                }
                else
                    throw new Exception("Hubo un error al leer el archivo json");


            }
            catch
            {
                throw;
            }

        }

        public List<BookModelNetCore> serializeRemoveJSON(string title, string jsonName)
        {
            try
            {
                string jsonBooks = File.ReadAllText(this.pathJSON + jsonName);

                var dictionaryBooks = JsonSerializer.Deserialize<Dictionary<string, List<BookModelNetCore>>>(jsonBooks);

                if (dictionaryBooks != null)
                {

                    List<BookModelNetCore> books = dictionaryBooks["books"];

                    // primero busco el libro en la lista, si existe lo borro sino lanzo exepcion
                    if (!books.Any(b => string.Compare(b.title, title) == 0))
                        throw new Exception("El libro que desea eliminar no existe");

                    books = books.Where(b => string.Compare(b.title, title, true) != 0).ToList();

                    // Serializar la lista actualizada de libros de nuevo a JSON
                    var updatedJson = JsonSerializer.Serialize(new { books });

                    // Escribir el JSON actualizado de nuevo en el archivo
                    File.WriteAllText(this.pathJSON + jsonName, updatedJson);

                    return books;
                }
                else
                    throw new Exception("Hubo un error al leer el archivo json de libros");
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

                if (jsonBooks != null)
                {
                    var dictionaryBooks = JsonSerializer.Deserialize<Dictionary<string, List<type>>>(jsonBooks);

                    if (dictionaryBooks != null)
                    {
                        List<type> books = dictionaryBooks[listName];
                        return books.ToList();
                    }
                    else
                        throw new Exception("Hubo un error al parsear el archivo json");
                }
                else
                    throw new Exception("Hubo un error al leer el archivo json");
            }
            catch
            {
                // Si entro aca es porque el archivo esta corrupto o no se pudo leer, entonces devuelvo una lista vacia
                return new List<type>();
            }
        }
    }
}
