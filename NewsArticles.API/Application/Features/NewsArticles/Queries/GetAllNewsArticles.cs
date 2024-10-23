using GenericServices;

using Mapster;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NewsArticles.API.Domain.DTOs;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Application.Features.NewsArticles.Queries;

internal sealed record GetAllNewsArticlesQuery() : IRequest<GetAllNewsArticlesViewModel>;
internal sealed record GetAllNewsArticlesViewModel(IEnumerable<NewsArticleWithAuthorDTO> NewsArticleDTOs);
internal sealed class GetAllNewsArticlesHandler(ICrudServicesAsync servicesAsync)
    : IRequestHandler<GetAllNewsArticlesQuery, GetAllNewsArticlesViewModel>
{
    public async Task<GetAllNewsArticlesViewModel> Handle(GetAllNewsArticlesQuery request, CancellationToken cancellationToken)
    {
        var newsArticles = await servicesAsync
            .ReadManyNoTracked<NewsArticle>()
            .ToListAsync();

        var newsArticleDTOs = newsArticles.Adapt<IEnumerable<NewsArticleWithAuthorDTO>>();

        return new GetAllNewsArticlesViewModel(newsArticleDTOs);
    }
}

