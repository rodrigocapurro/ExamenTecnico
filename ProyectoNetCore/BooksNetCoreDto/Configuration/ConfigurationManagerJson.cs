using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksNetCoreDto.Configuration
{
    public class ConfigurationManagerJson
    {
        public static string GetPathJsonFile()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(System.AppContext.BaseDirectory) // Ruta donde se encuentra el archivo appsettings.json
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            // Accede a los valores de appsettings.json
            string path = configuration["PathJSON"];

            if (!string.IsNullOrEmpty(path))
                return path;
            return string.Empty;

        }
    }
}
