using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IBookService
    {
        public Task<BookDto?> GetBookByIsbnAsync(string isbn);
    }
}
