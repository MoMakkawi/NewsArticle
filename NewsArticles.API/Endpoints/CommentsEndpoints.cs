using MediatR;

using Microsoft.AspNetCore.Mvc;

using NewsArticles.API.Application.Features.Comments.Commands;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Endpoints;

internal static class CommentsEndpoints
{
    public static void MapCommentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Comments").WithTags(nameof(Comment));

        group.MapPost("/", async ([FromServices] ISender mediatr, CreateCommentCommand createCommentCommand) =>
        {
            var createCommentVM = await mediatr.Send(createCommentCommand);
            return Results.Ok(createCommentVM);
        })
        .WithName("add new comment command")
        .WithOpenApi();
    }
}
