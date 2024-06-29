using MediatR;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Application.Features.NewsArticles.Commands;

internal sealed record DeleteNewsArticleRequest(Guid Id) : IRequest<DeleteNewsArticleResponse>;
internal sealed record DeleteNewsArticleResponse(string Message);

internal sealed class DeleteNewsArticleHandler(
    IBaseRepositoryAsync<NewsArticle> newsArticlesRepository,
    IImageServiceAsync imageServiceAsync)
    : IRequestHandler<DeleteNewsArticleRequest, DeleteNewsArticleResponse>
{
    public async Task<DeleteNewsArticleResponse> Handle(DeleteNewsArticleRequest request, CancellationToken cancellationToken)
    {
        var newsArticle = await newsArticlesRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new ArgumentException("There no news article with the input Id.");

        await imageServiceAsync.DeleteAsync(newsArticle.ImagesNames);
        await newsArticlesRepository.DeleteAsync(newsArticle.Id, cancellationToken);

        return new DeleteNewsArticleResponse("News article by Id deleted succesfully.");
    }
}
