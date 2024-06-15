using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Persistence.Data;

public class NewsArticleDBContext(DbContextOptions<NewsArticleDBContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Commenter> Commenters {  get; set; }

    public DbSet<NewsArticle> NewsArticles {  get; set; }
    public DbSet<Comment> Comments {  get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Author>()
            .HasMany(x => x.NewsArticles)
            .WithOne();

        builder.Entity<Commenter>()
            .HasMany<Comment>()
            .WithOne(x =>x.Commenter)
            .HasForeignKey(x => x.CommenterId);

        builder.Entity<Commenter>()
            .HasMany<Like>()
            .WithOne()
            .HasForeignKey(x => x.CommenterId);



        builder.Entity<PublishedDetails>()
            .HasOne(x => x.Author)
            .WithMany()
            .HasForeignKey(x => x.AuthorId);

        builder.Entity<NewsArticle>()
            .HasMany(x => x.Comments)
            .WithOne();

        builder.Entity<NewsArticle>()
            .HasOne(x => x.PublishedDetails)
            .WithOne();

    }

}
