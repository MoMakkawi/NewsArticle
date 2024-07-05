using MediatR;
using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Domain.Entities;
namespace NewsArticles.API.Application.Features.Interactions.Commands;

internal sealed record DeleteInteractionRequest(Guid Id) : IRequest<DeleteInteractionResponse>;
internal sealed record DeleteInteractionResponse(string Message);

internal sealed class DeleteInteractionHandler(IBaseRepositoryAsync<Interaction> interactionRepository)
    : IRequestHandler<DeleteInteractionRequest, DeleteInteractionResponse>
{
    public async Task<DeleteInteractionResponse> Handle(DeleteInteractionRequest request, CancellationToken cancellationToken)
    {
        await interactionRepository.DeleteAsync(request.Id, cancellationToken);
        return new DeleteInteractionResponse("Interaction by Id deleted successfully.");
    }
}