using NewsArticles.Domain.Entities;

namespace NewsArticles.Persistence.Identity;

public class Author : User
{
    public virtual required List<NewsArticle> NewsArticles { get; set; } = [];
}
