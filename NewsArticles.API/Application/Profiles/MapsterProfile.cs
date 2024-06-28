using Mapster;
using NewsArticles.API.Domain.DTOs;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Application.Profiles;

public static class MapsterProfile
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<NewsArticle, NewsArticleDTO>
            .NewConfig()
            .Map(dest => dest.CommentsCount, src => src.Comments.Count)
            .Map(dest => dest.InteractionsCount, src => src.Interactions.Count);

        TypeAdapterConfig<NewsArticle, NewsArticleWithAuthorDTO>
            .NewConfig()
            .Map(dest => dest.CommentsCount, src => src.Comments.Count)
            .Map(dest => dest.InteractionsCount, src => src.Interactions.Count)
            .Map(dest => dest.AuthorDTO, src => src.Author.Adapt<AuthorDTO>());
    }
}