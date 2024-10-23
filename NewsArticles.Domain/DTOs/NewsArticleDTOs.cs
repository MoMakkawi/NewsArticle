namespace NewsArticles.Domain.DTOs;

internal sealed record NewsArticleDTO(
    Guid Id,
    string Title,
    string Content,
    List<string> ImagesNames,
    int ViewsCount,
    int InteractionsCount,
    int CommentsCount,
    DateTime PublishedDate);

internal sealed record NewsArticleWithAuthorDTO(
    Guid Id,
    string Title,
    string Content,
    List<string> ImagesNames,
    int ViewsCount,
    int InteractionsCount,
    int CommentsCount,
    DateTime PublishedDate,

    AuthorDTO AuthorDTO);

internal sealed record NewsArticleDetailedDTO(
    Guid Id,
    string Title,
    string Content,
    List<string> ImagesNames,
    int ViewsCount,
    DateTime PublishedDate,
    int InteractionsCount,
    int CommentsCount,
    AuthorDTO AuthorDTO,

    List<InteractionDTO> InteractionDTOs,
    List<CommentDTO> CommentDTOs);