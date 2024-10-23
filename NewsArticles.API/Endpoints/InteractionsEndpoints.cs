using MediatR;

using Microsoft.AspNetCore.Mvc;

//using NewsArticles.API.Application.Features.Interactions.Commands;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Endpoints;

internal static class InteractionsEndpoints
{
    public static void MapInteractionsEndpoints(this IEndpointRouteBuilder routes)
    {
        //var group = routes.MapGroup("/api/Interactions").WithTags(nameof(Interaction));

        //group.MapPost("/", async ([FromServices] ISender mediatr, CreateInteractionCommand createInteractionCommand) =>
        //{
        //    var createInteractionVM = await mediatr.Send(createInteractionCommand);
        //    return Results.Ok(createInteractionVM);
        //})
        //.WithName("add new Interaction command")
        //.WithOpenApi();


        //group.MapDelete("/{id:guid}", async ([FromServices] ISender mediatr, Guid Id) =>
        //{
        //    var deleteInteractionVM = await mediatr.Send(new DeleteInteractionRequest(Id));
        //    return Results.Ok(deleteInteractionVM);
        //})
        //.WithName("delete Interaction command")
        //.WithOpenApi();
    }
}
