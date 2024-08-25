using Contracts;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Behaviors;
using Product.Application.MappingProfiles;
using Product.Application.UserCases.Product.V1.Validations;
using System.Reflection;
using static Shared.Services.Product.V1.Command;

namespace Product.Application.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollectionApplication(this IServiceCollection services)
    {
        services.AddScoped<IValidator<DeleteProductCommand>, DeleteProductCommandValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(ProductApplicationReference.Assembly);
        })
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformancePipelineBehavior<,>))
            .AddValidatorsFromAssembly(ProductApplicationReference.Assembly, includeInternalTypes: true);

        services.AddAutoMapper(typeof(AutoMapperConfig));

        return services;
    }
}