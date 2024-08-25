using Contracts.Abstractions.Common;
using Infrastructures.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceInfrastructuresBuildingBlock(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

        return services;
    }
}