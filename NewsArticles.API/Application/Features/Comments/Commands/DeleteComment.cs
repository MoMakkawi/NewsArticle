using GenericServices;

using MediatR;
using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;
namespace NewsArticles.API.Application.Features.Comments.Commands;

internal sealed record DeleteCommentRequest(Guid Id) : IRequest<DeleteCommentResponse>;
internal sealed record DeleteCommentResponse(string Message);

internal sealed class DeleteCommentHandler(ICrudServicesAsync serviceAsync)
    : IRequestHandler<DeleteCommentRequest, DeleteCommentResponse>
{
    public async Task<DeleteCommentResponse> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        await serviceAsync.DeleteAndSaveAsync<Comment>(request.Id);
        return new DeleteCommentResponse("Comment by Id deleted successfully.");
    }
}