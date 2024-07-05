using MediatR;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Application.Features.Comments.Commands;
internal sealed record CreateCommentCommand(Guid CommenterId, Guid ArticleId, string Content) : IRequest<CreateCommentResponse>;
internal sealed record CreateCommentResponse(string Message);
internal sealed class CreateCommentHandler(
    IBaseRepositoryAsync<NewsArticle> newsArticlesRepository,
    IBaseRepositoryAsync<Commenter> commenterRepository)
    : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
{
    public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var commenter = await commenterRepository.GetByIdAsync(request.CommenterId, cancellationToken)
            ?? throw new ArgumentException("There no Commenter with the input Id.");

        var newsArticle = await newsArticlesRepository.GetByIdAsync(request.ArticleId, cancellationToken)
            ?? throw new ArgumentException("There no news article with the input Id.");

        var comment = new Comment()
        {
            Commenter = commenter,
            CommenterId = request.CommenterId,
            Content = request.Content
        };

        newsArticle.Comments.Add(comment);

        await newsArticlesRepository.UpdateAsync(newsArticle.Id, newsArticle, cancellationToken);

        return new CreateCommentResponse("Comment added to the news article");
    }
}
