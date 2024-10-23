using MediatR;

using Microsoft.AspNetCore.Mvc;

//using NewsArticles.API.Application.Features.Comments.Commands;
using NewsArticles.API.Domain.Entities;

namespace NewsArticles.API.Endpoints;

internal static class CommentsEndpoints
{
    public static void MapCommentsEndpoints(this IEndpointRouteBuilder routes)
    {
        //var group = routes.MapGroup("/api/Comments").WithTags(nameof(Comment));

        //group.MapPost("/", async ([FromServices] ISender mediatr, CreateCommentCommand createCommentCommand) =>
        //{
        //    var createCommentVM = await mediatr.Send(createCommentCommand);
        //    return Results.Ok(createCommentVM);
        //})
        //.WithName("add new comment command")
        //.WithOpenApi();


        //group.MapDelete("/{id:guid}", async ([FromServices] ISender mediatr, Guid Id) =>
        //{
        //    var deleteCommentVM = await mediatr.Send(new DeleteCommentRequest(Id));
        //    return Results.Ok(deleteCommentVM);
        //})
        //.WithName("delete comment command")
        //.WithOpenApi();

        //group.MapPut("/", async ([FromServices] ISender mediatr, UpdateCommentCommand updateCommentCommand) =>
        //{
        //    var newsArticlesVM = await mediatr.Send(updateCommentCommand);
        //    return Results.Ok(newsArticlesVM);
        //})
        //.WithName("update Comment command")
        //.WithOpenApi();
    }
}
