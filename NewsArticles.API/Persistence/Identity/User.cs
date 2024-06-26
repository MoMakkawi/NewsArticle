using Microsoft.AspNetCore.Identity;

namespace NewsArticles.API.Persistence.Identity;

public class User : IdentityUser<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? ProfileImageName { get; set; }
}