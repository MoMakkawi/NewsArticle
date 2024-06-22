using Microsoft.EntityFrameworkCore;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Persistence.Data;
using NewsArticles.API.Persistence.Repositories;

namespace NewsArticles.API.Persistence;

public static class PersistenceContainer
{
    public static IServiceCollection AddPersistenceServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<NewsArticleDBContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("LocalContext") ??
                throw new InvalidOperationException("Connection string 'LocalContext' not found.")));

        builder.Services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));

        return builder.Services;
    }
}