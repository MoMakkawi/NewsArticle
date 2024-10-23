//using GenericServices;

//using MediatR;

//using NewsArticles.API.Application.Contracts;
//using NewsArticles.API.Domain.Entities;
//using NewsArticles.API.Persistence.Identity;

//namespace NewsArticles.API.Application.Features.NewsArticles.Commands;

//internal sealed record UpdateNewsArticleCommand(
//    Guid Id,
//    Guid AuthorId,

//    string Title,
//    string Content,
//    DateTime PublishedDate,
//    IFormFileCollection? Images)
//    : IRequest<UpdateNewsArticleResponse>;

//internal sealed record UpdateNewsArticleResponse(string Message);

//internal sealed class UpdateNewsArticlesHandler(ICrudServicesAsync servicesAsync, IImageServiceAsync imageServiceAsync)
//    : IRequestHandler<UpdateNewsArticleCommand, UpdateNewsArticleResponse>
//{
//    public async Task<UpdateNewsArticleResponse> Handle(UpdateNewsArticleCommand request, CancellationToken cancellationToken)
//    {
//        var author = await servicesAsync.ReadSingleAsync<Author>(request.AuthorId)
//            ?? throw new ArgumentException("There no Author with the input Id.");

//        var newsArticle = await servicesAsync.ReadSingleAsync<NewsArticle>(request.Id)
//            ?? throw new ArgumentException("There no news article with the input Id.");

//        newsArticle.ImagesNames = request.Images is null
//            ? newsArticle.ImagesNames
//            : await imageServiceAsync.SaveAsync(request.Images);

//        newsArticle.Author = author;
//        newsArticle.Title = request.Title;
//        newsArticle.Content = request.Content;
//        newsArticle.PublishedDate = request.PublishedDate;

//        await servicesAsync.UpdateAndSaveAsync(newsArticle);

//        return new UpdateNewsArticleResponse("News article by Id updated successfully.");
//    }
//}

