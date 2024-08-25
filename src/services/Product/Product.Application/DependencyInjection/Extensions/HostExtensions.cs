using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.Hosting;
using Product.Persistence.Repositories.Abstractions;
using Product.Application.AutofacModule;
using Product.Persistence.Repositories;
using Product.Infrastructure;

namespace Product.Application.DependencyInjection.Extensions;

public static class HostExtensions
{
    public static void AddHostApplication(this IHostBuilder host)
    {
        host.AddHostAutofac();
    }

    public static void AddHostAutofac(this IHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>((container) =>
        {
            container.RegisterModule(new GeneralModule<IRepositoryWrapper, RepositoryWrapper>(
                 ProductPersistenceReference.Assembly)
            );
        });
    }
}