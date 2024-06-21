namespace NewsArticles.API.Domain.DTOs;

internal sealed record CommentDTO(Guid Id, string Content, CommenterDTO CommenterDTO);