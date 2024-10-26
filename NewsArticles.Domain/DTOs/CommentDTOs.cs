namespace NewsArticles.Domain.DTOs;

internal sealed record CommentDTO(Guid Id, string Content, UserDTO CommenterDTO);