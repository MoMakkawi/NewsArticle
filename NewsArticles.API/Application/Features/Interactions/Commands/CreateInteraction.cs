using GenericServices;

using MediatR;
using NewsArticles.API.Domain.Entities;
using NewsArticles.API.Persistence.Identity;

namespace NewsArticles.API.Application.Features.Interactions.Commands;
internal sealed record CreateInteractionCommand(Guid CommenterId, Guid ArticleId) : IRequest<CreateInteractionResponse>
{
    public readonly InteractionType InteractionType = InteractionType.Like;
}
internal sealed record CreateInteractionResponse(string Message);
internal sealed class CreateInteractionHandler(ICrudServicesAsync servicesAsync)
    : IRequestHandler<CreateInteractionCommand, CreateInteractionResponse>
{
    public async Task<CreateInteractionResponse> Handle(CreateInteractionCommand request, CancellationToken cancellationToken)
    {
        var commenter = await servicesAsync.ReadSingleAsync<Commenter>(request.CommenterId)
            ?? throw new ArgumentException("There no Commenter with the input Id.");

        var newsArticle = await servicesAsync.ReadSingleAsync<NewsArticle>(request.ArticleId)
            ?? throw new ArgumentException("There no news article with the input Id.");

        var interaction = new Interaction()
        {
            Commenter = commenter,
            CommenterId = request.CommenterId,
            InteractionType = request.InteractionType
        };

        newsArticle.Interactions.Add(interaction);

        await servicesAsync.CreateAndSaveAsync(interaction);

        return new CreateInteractionResponse("Interaction added to the news article");
    }
}
