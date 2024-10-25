using Microsoft.AspNetCore.Identity;
using NewsArticles.Domain.Entities;

namespace NewsArticles.Persistence.Identity;

public class User : IdentityUser<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? ProfileImageName { get; set; }

    public virtual ICollection<NewsArticle>? NewsArticles { get; set; } 
}