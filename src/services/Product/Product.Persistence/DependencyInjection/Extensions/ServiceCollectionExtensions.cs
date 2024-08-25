using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Persistence.Interceptor;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure;
using Product.Persistence.Interceptors;
using Infrastructures.DependencyInjection.Extensions;

namespace Product.Persistence.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollectionPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServiceInterceptors();
        services.AddServiceInfrastructuresBuildingBlock();
        services.AddConfigurationDbContext(configuration);

        return services;
    }

    public static void AddServiceInterceptors(this IServiceCollection services)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddSingleton<DispatchDomainEventsInterceptor>();
    }

    public static void AddConfigurationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<ProductDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Product")
                , b => b.MigrationsAssembly(ProductPersistenceReference.AssemblyName))
                 .AddInterceptors(
                    sp.GetRequiredService<UpdateAuditableEntitiesInterceptor>(),
                    sp.GetRequiredService<DispatchDomainEventsInterceptor>());
        });
    }

}
