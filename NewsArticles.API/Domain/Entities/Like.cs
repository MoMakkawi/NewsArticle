using System.ComponentModel.DataAnnotations.Schema;

namespace NewsArticles.API.Domain.Entities;

[ComplexType]
public class Like
{
    public Guid UserId { get; set; }
}
