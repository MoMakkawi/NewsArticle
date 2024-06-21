namespace NewsArticles.API.Domain.DTOs;

internal sealed record CommenterDTO(
    Guid Id,
    string FirstName,
    string LastName,
    string? ProfileImagePath,
    string Email,
    string PhoneNumber);