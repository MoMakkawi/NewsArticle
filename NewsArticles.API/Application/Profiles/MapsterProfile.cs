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

        TypeAdapterConfig<Interaction, InteractionDTO>
           .NewConfig()
           .Map(dest => dest.CommenterDTO, src => src.Commenter.Adapt<CommenterDTO>());

        TypeAdapterConfig<Comment, CommentDTO>
            .NewConfig()
            .Map(dest => dest.CommenterDTO, src => src.Commenter.Adapt<CommenterDTO>());

        TypeAdapterConfig<NewsArticle, NewsArticleDetailedDTO>
            .NewConfig()
            .Map(dest => dest.CommentsCount, src => src.Comments.Count)
            .Map(dest => dest.InteractionsCount, src => src.Interactions.Count)
            .Map(dest => dest.AuthorDTO, src => src.Author.Adapt<AuthorDTO>())
            .Map(dest => dest.CommentDTOs, src => src.Comments.Adapt<List<CommentDTO>>())
            .Map(dest => dest.InteractionDTOs, src => src.Interactions.Adapt<List<InteractionDTO>>());
    }
}