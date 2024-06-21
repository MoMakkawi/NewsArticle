using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Domain.DTOs;

internal sealed record InteractionDTO(Guid Id, InteractionType InteractionType, CommenterDTO CommenterDTO);