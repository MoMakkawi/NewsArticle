using GenericServices;

using MediatR;

using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Application.Features.Comments.Commands;
internal sealed record CreateCommentCommand(Guid CommenterId, Guid ArticleId, string Content) : IRequest<CreateCommentResponse>;
internal sealed record CreateCommentResponse(string Message);
internal sealed class CreateCommentHandler(ICrudServicesAsync serviceAsync)
    : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
{
    public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var commenter = await serviceAsync.ReadSingleAsync<Commenter>(request.CommenterId)
            ?? throw new ArgumentException("There no Commenter with the input Id.");

        var newsArticle = await serviceAsync.ReadSingleAsync<NewsArticle>(request.ArticleId)
            ?? throw new ArgumentException("There no news article with the input Id.");

        var comment = new Comment()
        {
            Commenter = commenter,
            CommenterId = request.CommenterId,
            Content = request.Content
        };

        newsArticle.Comments.Add(comment);

        await serviceAsync.CreateAndSaveAsync(comment);

        return new CreateCommentResponse("Comment added to the news article");
    }
}
