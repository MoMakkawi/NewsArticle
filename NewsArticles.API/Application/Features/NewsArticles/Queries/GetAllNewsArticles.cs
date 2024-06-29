using Mapster;

using MediatR;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.DTOs;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Application.Features.NewsArticles.Queries;

internal sealed record GetAllNewsArticlesQuery() : IRequest<GetAllNewsArticlesViewModel>;
internal sealed record GetAllNewsArticlesViewModel(IEnumerable<NewsArticleWithAuthorDTO> NewsArticleDTOs);
internal sealed class GetAllNewsArticlesHandler(IBaseRepositoryAsync<NewsArticle> newsArticlesRepository)
    : IRequestHandler<GetAllNewsArticlesQuery, GetAllNewsArticlesViewModel>
{
    public async Task<GetAllNewsArticlesViewModel> Handle(GetAllNewsArticlesQuery request, CancellationToken cancellationToken)
    {
        var newsArticles = await newsArticlesRepository.GetAllAsync(cancellationToken);

        var newsArticleDTOs = newsArticles.Adapt<IEnumerable<NewsArticleWithAuthorDTO>>();

        return new GetAllNewsArticlesViewModel(newsArticleDTOs);
    }
}

