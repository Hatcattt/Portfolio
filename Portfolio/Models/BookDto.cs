namespace Portfolio.Models
{
    public class BookDto
    {
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = [];
        public int PageCount { get; set; }
        public List<Identifier> Identifiers { get; set; } = [];
        public string ImageUrl { get; set; } = string.Empty;

        public class Identifier
        {
            public string Type { get; set; } = string.Empty;
            public string ISBN { get; set; } = string.Empty;
        }
    }
}
