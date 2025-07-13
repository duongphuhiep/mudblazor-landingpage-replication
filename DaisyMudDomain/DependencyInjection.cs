using Microsoft.Extensions.DependencyInjection;

namespace DaisyMudDomain;

public static class DependencyInjection
{
    public static IServiceCollection AddMudDomainServices(this IServiceCollection services)
    {
        services.AddSingleton<SearchService>();
        services.AddSingleton<CountryListService>();
        services.AddSingleton<StatsService>();
        services.AddSingleton<TestimonialService>();
        services.AddSingleton<NotificationService>();
        return services;
    }
}