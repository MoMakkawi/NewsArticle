using System.Reflection;

namespace NewsArticles.API.Application.Profiles;

internal static class ApplicationContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.RegisterMapsterConfiguration();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}