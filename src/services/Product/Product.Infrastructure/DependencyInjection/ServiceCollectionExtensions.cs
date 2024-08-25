using Microsoft.Extensions.DependencyInjection;

namespace Product.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollectionInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}
