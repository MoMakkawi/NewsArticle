namespace NewsArticles.Domain.Entities;
public class NewsArticle
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required int ViewsCount {  get; set; }
    public required List<string> ImagesNames { get; set; } = [];
    public DateTime PublishedDate { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; } = [];
    public virtual ICollection<Comment> Comments { get; set; } = [];

    public required Guid AuthorId { get; set; }
}