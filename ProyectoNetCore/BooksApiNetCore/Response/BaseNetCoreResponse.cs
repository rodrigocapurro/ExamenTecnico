namespace BooksApiNetCore.Response
{
    public class BaseNetCoreResponse
    {
        public int cod_Http { get; set; }

        public string status { get; set; }

        public string mensaje { get; set; }
    }
}
