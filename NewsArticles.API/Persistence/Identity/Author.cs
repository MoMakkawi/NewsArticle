using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Persistence.Identity;

public class Author : User
{
    public required List<NewsArticle> NewsArticles { get; set; } = [];
}
