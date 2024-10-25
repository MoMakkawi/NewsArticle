using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using NewsArticles.Domain.Entities;
using NewsArticles.Persistence.Identity;

namespace NewsArticles.Persistence.Data;

public class NewsArticleDBContext(DbContextOptions<NewsArticleDBContext> options) 
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<NewsArticle> NewsArticles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany<Comment>()
            .WithOne()
            .HasForeignKey(x => x.CommenterId);

        builder.Entity<User>()
            .HasMany<Interaction>()
            .WithOne()
            .HasForeignKey(x => x.CommenterId);

        builder.Entity<User>()
            .HasMany(x => x.NewsArticles)
            .WithOne()
            .HasForeignKey(x => x.AuthorId);

        builder.Entity<NewsArticle>()
            .HasMany(x => x.Interactions)
            .WithOne();

        builder.Entity<NewsArticle>()
            .HasMany(x => x.Comments)
            .WithOne();

        base.OnModelCreating(builder);
    }

}
