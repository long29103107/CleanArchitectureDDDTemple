using System.Reflection;

namespace Product.Infrastructure;
public static class ProductInfrastructureReference
{
    public static readonly Assembly Assembly = typeof(ProductInfrastructureReference).Assembly;
    public static readonly string AssemblyName = typeof(ProductInfrastructureReference).Assembly.GetName().Name!;
}