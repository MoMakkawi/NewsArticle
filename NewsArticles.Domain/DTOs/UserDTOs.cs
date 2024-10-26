namespace NewsArticles.Domain.DTOs;

internal sealed record UserDTO(
    Guid Id,
    string FirstName,
    string LastName,
    string? ProfileImageName,
    string Email,
    string PhoneNumber);

internal sealed record UserWithNewsArticlesDTO(UserDTO UserDTO, List<NewsArticleDTO> NewsArticleDTOs);
