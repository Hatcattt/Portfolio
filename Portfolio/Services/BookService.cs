using Portfolio.Models;
using System.Net;
using System.Net.Http.Json;

namespace Portfolio.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://www.googleapis.com/books/v1/volumes?q=isbn:";

        public BookService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<BookDto?> GetBookByIsbnAsync(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return null;

            var url = _baseUrl + $"{identifier}";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<GoogleBookApiResponse.Root>();
            var volumeInfo = result?.Items?.FirstOrDefault()?.VolumeInfo;

            if (volumeInfo is null) { return new BookDto(); }

            //var image = Book.DEFAULT_BOOK_IMAGE_URL;
            var image = string.Empty;

            if (volumeInfo.ImageLinks is not null)
            {
                image = volumeInfo.ImageLinks.Thumbnail.Replace("http://", "https://");
            }

            return new BookDto()
            {
                Title = volumeInfo.Title,
                SubTitle = volumeInfo.Subtitle,
                ImageUrl = image,
                Identifiers = [.. volumeInfo.IndustryIdentifiers.Select(id => new BookDto.Identifier() { ISBN = id.Identifier, Type = id.Type })],
                Authors = volumeInfo.Authors,
                PageCount = volumeInfo.PageCount,
            };
        }
    }
}
