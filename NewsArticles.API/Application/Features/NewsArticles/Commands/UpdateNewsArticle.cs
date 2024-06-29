using MediatR;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Application.Features.NewsArticles.Commands;

internal sealed record UpdateNewsArticleCommand(
    Guid Id,
    Guid AuthorId,

    string Title,
    string Content,
    DateTime PublishedDate,
    IFormFileCollection? Images)
    : IRequest<UpdateNewsArticleResponse>;

internal sealed record UpdateNewsArticleResponse(string Message);

internal sealed class UpdateNewsArticlesHandler(
    IBaseRepositoryAsync<NewsArticle> newsArticlesRepository,
    IImageServiceAsync imageServiceAsync,
    IBaseRepositoryAsync<Author> authorRepository)
    : IRequestHandler<UpdateNewsArticleCommand, UpdateNewsArticleResponse>
{
    public async Task<UpdateNewsArticleResponse> Handle(UpdateNewsArticleCommand request, CancellationToken cancellationToken)
    {
        var author = await authorRepository.GetByIdAsync(request.AuthorId, cancellationToken)
            ?? throw new ArgumentException("There no Author with the input Id.");

        var newsArticle = await newsArticlesRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new ArgumentException("There no news article with the input Id.");

        newsArticle.ImagesNames = request.Images is null
            ? newsArticle.ImagesNames
            : await imageServiceAsync.SaveAsync(request.Images);

        newsArticle.Author = author;
        newsArticle.Title = request.Title;
        newsArticle.Content = request.Content;
        newsArticle.PublishedDate = request.PublishedDate;

        await newsArticlesRepository.UpdateAsync(request.Id, newsArticle, cancellationToken);

        return new UpdateNewsArticleResponse("News article by Id updated successfully.");
    }
}

