using System.Reflection;

namespace Product.Application;
public static class ProductApplicationReference
{
    public static readonly Assembly Assembly = typeof(ProductApplicationReference).Assembly;
    public static readonly string AssemblyName = typeof(ProductApplicationReference).Assembly.GetName().Name!;
}