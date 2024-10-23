using NewsArticles.Domain.Entities;

namespace NewsArticles.Domain.DTOs;

internal sealed record InteractionDTO(Guid Id, InteractionType InteractionType, CommenterDTO CommenterDTO);