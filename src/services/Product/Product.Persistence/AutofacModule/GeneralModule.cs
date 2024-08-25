using Autofac;

namespace Product.Persistence.AutofacModule;

public class GeneralModule<TInterface, TClass>(
    //System.Reflection.Assembly _assemblyService,
    System.Reflection.Assembly _assemblyRepository
) : Module
    where TClass : class
    where TInterface : class
{
    protected override void Load(ContainerBuilder container)
    {
        //container.RegisterAssemblyTypes(_assemblyService)
        //       .Where(t => t.Name.EndsWith(EndWithConstans.Impmentations.EndsWithService))
        //       .AsImplementedInterfaces()
        //       .InstancePerLifetimeScope();
        container.RegisterAssemblyTypes(_assemblyRepository)
            .Where(t => t.Name.EndsWith(EndWithConstans.Impmentations.EndsWithRepository))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        container.RegisterType<TClass>()
            .As<TInterface>()
            .InstancePerLifetimeScope();
    }
}


public class GeneralModule(
    //System.Reflection.Assembly _assemblyService, 
    System.Reflection.Assembly _assemblyRepository
) : Module
{
    protected override void Load(ContainerBuilder container)
    {
        //container.RegisterAssemblyTypes(_assemblyService)
        //       .Where(t => t.Name.EndsWith(Constants.Impmentations.EndsWithService))
        //       .AsImplementedInterfaces()
        //       .InstancePerLifetimeScope();
        container.RegisterAssemblyTypes(_assemblyRepository)
            .Where(t => t.Name.EndsWith(EndWithConstans.Impmentations.EndsWithRepository))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}