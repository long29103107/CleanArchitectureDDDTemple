using Infrastructures;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.MappingProfiles;

namespace Product.Application.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddServiceApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([ ProductApplicationReference.Assembly, InfrastructuresReference.Assembly]));
        services.AddAutoMapper(typeof(AutoMapperConfig));

        return services;
    }
}