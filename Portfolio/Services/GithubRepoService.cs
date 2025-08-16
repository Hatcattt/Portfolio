using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class GithubRepoService(HttpClient httpClient, ILogger<GithubRepoService> logger) : IGithubRepoService
{
    private const string ApiUrl = "https://api.github.com/users/hatcattt/repos";
    
    public async Task<List<GithubRepoDto>?> GetRepositories()
    {
        // normally, I use the Result Pattern
        try
        {
            var repos = await httpClient.GetFromJsonAsync<List<GithubRepoDto>>(ApiUrl);
            return repos?
                .OrderByDescending(repo => repo.CreateAt)
                .Select(repo =>
                {
                    repo.Name = repo.Name;
                    repo.Description = repo.Description;
                    repo.Url = repo.Url;
                    repo.Language =
                        repo.Name.StartsWith("Portfolio")
                            ? "C#/Blazor"
                            : repo.Language; // prevent to have "Javascript" from GitHub
                    repo.CreateAt = repo.CreateAt;
                    repo.UpdateAt = repo.UpdateAt;
                    return repo;
                }).ToList();
        }
        catch (Exception ex)
        {
            logger.LogError("Error while feetching data on the GitHub REST API. Please try again later.");
        }
        return [];
    }
}