using BooksData.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace BooksDto.DataSourceBooks
{
    public class JsonConfig
    {
        protected readonly string pathJSON = ConfigurationManager.AppSettings["pathJSON"];

        public List<type> GetFile<type>(string json, string jsonListName)
        {
            return JsonSerializer.Deserialize<Dictionary<string, List<type>>>(json)[jsonListName];
        }
    }
}
