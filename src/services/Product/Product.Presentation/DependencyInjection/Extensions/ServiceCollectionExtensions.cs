using Carter;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Package.Shared.ExceptionHandler;

namespace Product.Presentation.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceCollectionPresentation(this IServiceCollection services)
    {
        services.AddExceptionHandler();
        services.ConfigureApiVersionMapping();
        services.ConfigureSwaggerApi();

        return services;
    }

    public static void AddExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }

    public static void ConfigureApiVersionMapping(this IServiceCollection services)
    {
        services.AddCarter();
        services.AddApiVersioning(options => options.ReportApiVersions = true)
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }

    public static void ConfigureSwaggerApi(this IServiceCollection services)
        => services.AddSwaggerGenNewtonsoftSupport()
                .AddFluentValidationRulesToSwagger()
                .AddEndpointsApiExplorer()
                .AddSwaggerAPI();
}