﻿namespace NewsArticles.API.Domain.DTOs;

internal sealed record AuthorDTO(
    Guid Id,
    string FirstName,
    string LastName,
    string? ProfileImagePath,
    string Email,
    string PhoneNumber);

internal sealed record AuthorWithNewsArticlesDTO(
    Guid Id,
    string FirstName,
    string LastName,
    string? ProfileImagePath,
    string Email,
    string PhoneNumber,

    List<NewsArticleDTO> NewsArticleDTOs);