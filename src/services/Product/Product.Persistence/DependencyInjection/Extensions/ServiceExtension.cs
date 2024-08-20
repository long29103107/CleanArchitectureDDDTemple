using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Persistence.Interceptor;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure;

namespace Product.Persistence.DependencyInjection.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServicePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContext<ProductDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Product")
                , b => b.MigrationsAssembly(ProductPersistenceReference.AssemblyName))
                 .AddInterceptors(
                    sp.GetRequiredService<UpdateAuditableEntitiesInterceptor>());
        });

        return services;
    }
}