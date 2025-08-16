using Portfolio.Models;

namespace Portfolio.Services;

public interface IGithubRepoService
{
    public Task<List<GithubRepoDto>?> GetRepositories();
}