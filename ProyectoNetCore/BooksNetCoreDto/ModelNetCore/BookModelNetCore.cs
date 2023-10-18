using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksNetCoreDto.ModelNetCore
{
    public class BookModelNetCore
    {
        public string title { get; set; }

        public string author { get; set; }

        public int publicationYear { get; set; }

        public string isbn { get; set; }
    }
}
