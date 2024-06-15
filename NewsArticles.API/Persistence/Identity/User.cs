using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace NewsArticles.API.Persistence.Identity;

public class User : IdentityUser<Guid>
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? ProfileImagePath { get; set; }
}