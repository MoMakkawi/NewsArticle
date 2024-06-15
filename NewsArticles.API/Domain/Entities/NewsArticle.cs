namespace NewsArticles.API.Domain.Entities;

public class NewsArticle
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required List<string> ImagePaths { get; set; } = [];

    public required PublishedDetails PublishedDetails { get; set; }

    public List<Like> Likes { get; set; } = [];
    public virtual ICollection<Comment> Comments { get; set; } = [];

    public Guid AuthorId { get; set; }
}
