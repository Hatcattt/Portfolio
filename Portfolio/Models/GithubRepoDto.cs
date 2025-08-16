using System.Text.Json.Serialization;

namespace Portfolio.Models;

public class GithubRepoDto
{
    public string Name { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
        
    [JsonPropertyName("html_url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("created_at")]
    public DateTime CreateAt { get; set; }
        
    [JsonPropertyName("updated_at")]
    public DateTime UpdateAt { get; set; }
}