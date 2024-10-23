//using GenericServices;

//using MediatR;
//using NewsArticles.API.Domain.Entities;
//namespace NewsArticles.API.Application.Features.Interactions.Commands;

//internal sealed record DeleteInteractionRequest(Guid Id) : IRequest<DeleteInteractionResponse>;
//internal sealed record DeleteInteractionResponse(string Message);

//internal sealed class DeleteInteractionHandler(ICrudServicesAsync servicesAsync)
//    : IRequestHandler<DeleteInteractionRequest, DeleteInteractionResponse>
//{
//    public async Task<DeleteInteractionResponse> Handle(DeleteInteractionRequest request, CancellationToken cancellationToken)
//    {
//        await servicesAsync.DeleteAndSaveAsync<Interaction>(request.Id);
//        return new DeleteInteractionResponse("Interaction by Id deleted successfully.");
//    }
//}