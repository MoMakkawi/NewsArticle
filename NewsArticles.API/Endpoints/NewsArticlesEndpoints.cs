using MediatR;

using Microsoft.AspNetCore.Mvc;

using NewsArticles.API.Application.Features.NewsArticles.Commands;
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

        group.MapPost("/", async ([FromServices] ISender mediatr, [FromForm] CreateNewsArticleCommand createNewsArticleCommand) =>
        {
            var newsArticlesVM = await mediatr.Send(createNewsArticleCommand);
            return Results.Ok(newsArticlesVM);
        })
        .DisableAntiforgery()
        .Accepts<CreateNewsArticleCommand>("multipart/form-data")
        .WithName("add news article command")
        .WithOpenApi();
    }
}