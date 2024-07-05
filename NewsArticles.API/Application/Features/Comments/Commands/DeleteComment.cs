using MediatR;
using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;
namespace NewsArticles.API.Application.Features.Comments.Commands;

internal sealed record DeleteCommentRequest(Guid Id) : IRequest<DeleteCommentResponse>;
internal sealed record DeleteCommentResponse(string Message);

internal sealed class DeleteCommentHandler(IBaseRepositoryAsync<Comment> commentRepository)
    : IRequestHandler<DeleteCommentRequest, DeleteCommentResponse>
{
    public async Task<DeleteCommentResponse> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        await commentRepository.DeleteAsync(request.Id, cancellationToken);
        return new DeleteCommentResponse("Comment by Id deleted successfully.");
    }
}