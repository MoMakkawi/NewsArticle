﻿using Mapster;

using MediatR;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Application.Features.NewsArticles.Commands;

internal sealed record CreateNewsArticleCommand(
    Guid AuthorId,

    string Title,
    string Content,
    DateTime PublishedDate,
    IFormFileCollection? Images)
    : IRequest<CreateNewsArticleResponse>
{
    public readonly int ViewsCount = 1;
}

internal sealed record CreateNewsArticleResponse(
    Guid Id,
    string Title,
    string Content,
    List<string> ImagesNames,
    DateTime PublishedDate);

internal sealed class CreateNewsArticlesHandler(
    IBaseRepositoryAsync<NewsArticle> newsArticlesRepository,
    IImageServiceAsync imageServiceAsync,
    IBaseRepositoryAsync<Author> authorRepository)
    : IRequestHandler<CreateNewsArticleCommand, CreateNewsArticleResponse>
{
    public async Task<CreateNewsArticleResponse> Handle(CreateNewsArticleCommand request, CancellationToken cancellationToken)
    {
        var author = await authorRepository.GetByIdAsync(request.AuthorId, cancellationToken)
            ?? throw new ArgumentException("There no Author with the input Id.");

        var savedImagesNames = await imageServiceAsync.SaveAsync(request.Images);

        var newsArticle = request.Adapt<NewsArticle>();
        newsArticle.ImagesNames = savedImagesNames;
        newsArticle.Author = author;

        var savedNewsArticle = await newsArticlesRepository.CreateAsync(newsArticle, cancellationToken);

        return savedNewsArticle.Adapt<CreateNewsArticleResponse>();

    }
}

