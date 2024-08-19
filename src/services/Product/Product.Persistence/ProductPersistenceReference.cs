using System.Reflection;

namespace Product.Infrastructure;
public static class ProductPersistenceReference
{
    public static readonly Assembly Assembly = typeof(ProductPersistenceReference).Assembly;
    public static readonly string AssemblyName = typeof(ProductPersistenceReference).Assembly.GetName().Name!;
}