using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.DependencyInjection.Extensions;

public static class ConfigurationExtensions
{
    public static T AddSingletonOptions<T>(this IServiceCollection services, string sectionName) where T : class
    {
        using var serviceProvider = services.BuildServiceProvider();

        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        var section = configuration.GetSection(sectionName);

        var options = (T)Activator.CreateInstance(typeof(T));

        section.Bind(options);

        services.AddSingleton<T>(options);

        return options;
    }
}