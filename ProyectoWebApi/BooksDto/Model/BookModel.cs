using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksData.Model
{
    public class BookModel
    {
        public string title { get; set; }

        public string author { get; set; }

        public int publicationYear { get; set; }

        public string isbn { get; set; }

    }
}
