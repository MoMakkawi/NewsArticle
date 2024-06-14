using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Persistence.Data;

public class NewsArticleDBContext(DbContextOptions<NewsArticleDBContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<NewsArticle> NewsArticles {  get; set; }
    public DbSet<Comment> Comments {  get; set; }

}
