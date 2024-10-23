//using GenericServices;

//using MediatR;

//using NewsArticles.API.Application.Contracts;
//using NewsArticles.API.Domain.Entities;

//namespace NewsArticles.API.Application.Features.NewsArticles.Commands;

//internal sealed record DeleteNewsArticleRequest(Guid Id) : IRequest<DeleteNewsArticleResponse>;
//internal sealed record DeleteNewsArticleResponse(string Message);

//internal sealed class DeleteNewsArticleHandler(ICrudServicesAsync servicesAsync, IImageServiceAsync imageServiceAsync)
//    : IRequestHandler<DeleteNewsArticleRequest, DeleteNewsArticleResponse>
//{
//    public async Task<DeleteNewsArticleResponse> Handle(DeleteNewsArticleRequest request, CancellationToken cancellationToken)
//    {
//        var newsArticle = await servicesAsync.ReadSingleAsync<NewsArticle>(request.Id)
//            ?? throw new ArgumentException("There no news article with the input Id.");

//        await imageServiceAsync.DeleteAsync(newsArticle.ImagesNames);
//        await servicesAsync.DeleteAndSaveAsync<NewsArticle>(newsArticle.Id);

//        return new DeleteNewsArticleResponse("News article by Id deleted successfully.");
//    }
//}
