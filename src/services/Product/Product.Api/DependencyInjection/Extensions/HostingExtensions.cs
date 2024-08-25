using Package.Shared.ExceptionHandler;
using Serilog;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Carter;
using Product.Presentation.DependencyInjection.Extensions;
using Product.Application.DependencyInjection.Extensions;
using Product.Persistence.DependencyInjection.Extensions;
using Product.Infrastructure.DependencyInjection.Extensions;

namespace Product.Api.DependencyInjection.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddServiceCollectionApi()
            .AddServiceCollectionApplication()
            .AddServiceCollectionPersistence(builder.Configuration)
            .AddServiceCollectionPresentation();

        builder.Host.AddHostPersistence();
        builder.Host.AddHostInfrastructure();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app, WebApplicationBuilder builder)
    {
        app.UseExceptionHandler();

        //app.UseHttpsRedirection();

        //app.UseAuthentication(); 

        //app.UseAuthorization();

        // Add API Endpoint with carter module
        app.MapCarter();

        app.UseSwaggerAPI(); // Map carter and show api

        return app;
    }
}