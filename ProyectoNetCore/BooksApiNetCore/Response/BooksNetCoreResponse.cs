using BooksNetCoreDto.ModelNetCore;

namespace BooksApiNetCore.Response
{
    public class BooksNetCoreResponse: BaseNetCoreResponse
    {
        public List<BookModelNetCore> booksList { get; set; }
    }
}
