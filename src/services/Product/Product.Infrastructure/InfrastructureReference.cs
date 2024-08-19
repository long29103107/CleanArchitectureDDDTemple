using System.Reflection;

namespace Product.Infrastructure;
public static class InfrastructureReference
{
    public static readonly Assembly Assembly = typeof(InfrastructureReference).Assembly;
    public static readonly string AssemblyName = typeof(InfrastructureReference).Assembly.GetName().Name!;
}