﻿using Microsoft.EntityFrameworkCore;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Application.Services;
using NewsArticles.API.Persistence.Data;

namespace NewsArticles.API.Persistence;

public static class PersistenceContainer
{
    public static IServiceCollection AddPersistenceServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<NewsArticleDBContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("LocalContext") ??
                throw new InvalidOperationException("Connection string 'LocalContext' not found.")));

        builder.Services.AddScoped<IImageServiceAsync, ImageServiceAsync>();

        return builder.Services;
    }
}