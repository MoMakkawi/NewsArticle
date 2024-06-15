using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Domain.Entities;

public class PublishedDetails
{
    public Guid Id { get; set; }
    public DateTime PublishedDate { get; set; }

    public Guid AuthorId { get; set; }
    public virtual required Author Author { get; set; }

    public Guid NewsArticleId { get; set; }
}
