namespace NewsArticles.API.Domain.Entities;

public class Interaction
{
    public Guid Id { get; set; }
    public InteractionType InteractionType { get; set; }

    public Guid CommenterId { get; set; }
}
