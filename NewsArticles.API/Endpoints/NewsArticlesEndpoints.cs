using MediatR;

using Microsoft.AspNetCore.Mvc;

//using NewsArticles.API.Application.Features.NewsArticles.Commands;
using NewsArticles.API.Application.Features.NewsArticles.Queries;

namespace NewsArticles.API.Endpoints;

internal static class NewsArticlesEndpoints
{
    public static void MapNewsArticlesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/NewsArticles").WithTags(nameof(NewsArticles));

        group.MapGet("/", async ([FromServices] ISender mediatr) =>
        {
            var newsArticlesVM = await mediatr.Send(new GetAllNewsArticlesQuery());
            return Results.Ok(newsArticlesVM);
        })
        .WithName("get all news articles")
        .WithOpenApi();

        //group.MapGet("/{id:guid}", async ([FromServices] ISender mediatr, Guid Id) =>
        //{
        //    var detailedNewsArticlesVM = await mediatr.Send(new GetDetailedNewsArticleQuery(Id));
        //    return Results.Ok(detailedNewsArticlesVM);
        //})
        //.WithName("get detailed news articles")
        //.WithOpenApi();

        //group.MapPost("/", async ([FromServices] ISender mediatr, [FromForm] CreateNewsArticleCommand createNewsArticleCommand) =>
        //{
        //    var newsArticlesVM = await mediatr.Send(createNewsArticleCommand);
        //    return Results.Ok(newsArticlesVM);
        //})
        //.DisableAntiforgery()
        //.Accepts<CreateNewsArticleCommand>("multipart/form-data")
        //.WithName("add news article command")
        //.WithOpenApi();

        //group.MapDelete("/{id:guid}", async ([FromServices] ISender mediatr, Guid Id) =>
        //{
        //    var newsArticlesVM = await mediatr.Send(new DeleteNewsArticleRequest(Id));
        //    return Results.Ok(newsArticlesVM);
        //})
        //.WithName("delete news article command")
        //.WithOpenApi();

        //group.MapPut("/", async ([FromServices] ISender mediatr, [FromForm] UpdateNewsArticleCommand updateNewsArticleCommand) =>
        //{
        //    var newsArticlesVM = await mediatr.Send(updateNewsArticleCommand);
        //    return Results.Ok(newsArticlesVM);
        //})
        //.DisableAntiforgery()
        //.Accepts<UpdateNewsArticleCommand>("multipart/form-data")
        //.WithName("update news article command")
        //.WithOpenApi();
    }
}