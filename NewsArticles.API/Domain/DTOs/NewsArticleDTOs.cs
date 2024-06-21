namespace NewsArticles.API.Domain.DTOs;

internal sealed record NewsArticleDTO(
    Guid Id,
    string Title,
    string Content,
    List<string> ImagePaths,
    int ViewsCount,
    int InteractionsCount,
    int CommentsCount,

    DateTime PublishedDate);

internal sealed record NewsArticleWithAuthorDTO(
    Guid Id,
    string Title,
    string Content,
    List<string> ImagePaths,
    int ViewsCount,
    int InteractionsCount,
    int CommentsCount,

    DateTime PublishedDate,

    AuthorDTO AuthorDTO);