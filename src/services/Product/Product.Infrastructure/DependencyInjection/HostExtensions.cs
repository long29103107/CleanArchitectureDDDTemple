using Microsoft.Extensions.Hosting;
using Serilog;

namespace Product.Infrastructure.DependencyInjection.Extensions;

public static class HostExtensions
{
    public static void AddHostInfrastructure(this IHostBuilder host)
    {
        host.AddHostSerilog();
    }

    public static void AddHostSerilog(this IHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        host.UseSerilog((context, loggerConfiguration) =>
        {
            loggerConfiguration.WriteTo.Console();
            loggerConfiguration.ReadFrom.Configuration(context.Configuration);
        });
    }
}