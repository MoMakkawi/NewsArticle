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

internal sealed record NewsArticleWithAuthorDTO(NewsArticleDTO NewsArticleDTO, UserDTO AuthorDTO);

internal sealed record NewsArticleDetailedDTO(
    NewsArticleDTO NewsArticleDTO,
    UserDTO AuthorDTO,
    List<InteractionDTO> InteractionDTOs,
    List<CommentDTO> CommentDTOs);