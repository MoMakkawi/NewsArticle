//using GenericServices;

//using Mapster;

//using MediatR;

//using Microsoft.AspNetCore.Mvc;

//using NewsArticles.API.Domain.DTOs;
//using NewsArticles.API.Domain.Entities;

//namespace NewsArticles.API.Application.Features.NewsArticles.Queries;

//internal sealed record GetDetailedNewsArticleQuery(Guid Id) : IRequest<GetDetailedNewsArticleViewModel>;
//internal sealed record GetDetailedNewsArticleViewModel(
//     Guid Id,
//    string Title,
//    string Content,
//    List<string> ImagesNames,
//    int ViewsCount,
//    DateTime PublishedDate,
//    int InteractionsCount,
//    int CommentsCount,
//    AuthorDTO AuthorDTO,

//    List<InteractionDTO> InteractionDTOs,
//    List<CommentDTO> CommentDTOs);

//internal sealed class GetDetailedNewsArticleHandler([FromServices] ICrudServicesAsync servicesAsync)
//    : IRequestHandler<GetDetailedNewsArticleQuery, GetDetailedNewsArticleViewModel>
//{
//    public async Task<GetDetailedNewsArticleViewModel> Handle(GetDetailedNewsArticleQuery request, CancellationToken cancellationToken)
//    {
//        var newsArticle = await servicesAsync.ReadSingleAsync<NewsArticle>(request.Id)
//            ?? throw new ArgumentException("There no news article with the input Id.");

//        var detailedNewsArticle = newsArticle.Adapt<NewsArticleDetailedDTO>();

//        return detailedNewsArticle.Adapt<GetDetailedNewsArticleViewModel>() with
//        { 
//            AuthorDTO = detailedNewsArticle.AuthorDTO,
//            CommentDTOs = newsArticle.Comments.Adapt<List<CommentDTO>>(),
//            InteractionDTOs = newsArticle.Interactions.Adapt<List<InteractionDTO>>(),
//        };
//    }
//}
