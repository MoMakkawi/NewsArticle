namespace NewsArticles.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public required string Content { get; set; }

    public Guid CommenterId { get; set; }
    public virtual required Commenter Commenter { get; set; }
}