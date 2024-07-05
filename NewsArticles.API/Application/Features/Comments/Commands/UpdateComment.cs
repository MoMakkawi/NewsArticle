using MediatR;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Application.Features.Comments.Commands;
internal sealed record UpdateCommentCommand(Guid Id, string Content) : IRequest<UpdateCommentResponse>;
internal sealed record UpdateCommentResponse(string Message);
internal sealed class UpdateCommentHandler(IBaseRepositoryAsync<Comment> commentRepository)
    : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
{
    public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new ArgumentException("There no Comment with the input Id.");

        comment.Content = request.Content;

        await commentRepository.UpdateAsync(request.Id, comment, cancellationToken);

        return new UpdateCommentResponse("Comment added to the news article repository");
    }
}
