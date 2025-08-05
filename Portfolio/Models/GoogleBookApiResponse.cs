using System.Text.Json.Serialization;

namespace Portfolio.Models
{
    public class GoogleBookApiResponse
    {
        public class Root
        {
            [JsonPropertyName("items")]
            public List<Item> Items { get; set; } = [];
        }

        public class IndustryIdentifier
        {
            [JsonPropertyName("type")]
            public string Type { get; set; } = string.Empty;

            [JsonPropertyName("identifier")]
            public string Identifier { get; set; } = string.Empty;
        }

        public class VolumeInfo
        {
            [JsonPropertyName("title")]
            public string Title { get; set; } = string.Empty;

            [JsonPropertyName("subtitle")]
            public string Subtitle { get; set; } = string.Empty;

            [JsonPropertyName("authors")]
            public List<string> Authors { get; set; } = new();

            [JsonPropertyName("publisher")]
            public string Publisher { get; set; } = string.Empty;

            [JsonPropertyName("publishedDate")]
            public string PublishedDate { get; set; } = string.Empty;

            [JsonPropertyName("description")]
            public string Description { get; set; } = string.Empty;

            [JsonPropertyName("industryIdentifiers")]
            public List<IndustryIdentifier> IndustryIdentifiers { get; set; } = [];

            [JsonPropertyName("pageCount")]
            public int PageCount { get; set; }

            [JsonPropertyName("averageRating")]
            public double AverageRating { get; set; }

            [JsonPropertyName("ratingsCount")]
            public int RatingsCount { get; set; }

            [JsonPropertyName("maturityRating")]
            public string MaturityRating { get; set; } = string.Empty;

            [JsonPropertyName("language")]
            public string Language { get; set; } = string.Empty;

            [JsonPropertyName("previewLink")]
            public string PreviewLink { get; set; } = string.Empty;

            [JsonPropertyName("imageLinks")]
            public ImageLinks? ImageLinks { get; set; }
        }

        public class Item
        {
            [JsonPropertyName("kind")]
            public string Kind { get; set; } = string.Empty;

            [JsonPropertyName("volumeInfo")]
            public VolumeInfo VolumeInfo { get; set; } = new();
        }

        public class ImageLinks
        {
            [JsonPropertyName("smallThumbnail")]
            public string SmallThumbnail { get; set; } = string.Empty;

            [JsonPropertyName("thumbnail")]
            public string Thumbnail { get; set; } = string.Empty;
        }
    }
}
