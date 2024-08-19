using System.Reflection;

namespace Product.Application;
public static class ProductApiReference
{
    public static readonly Assembly Assembly = typeof(ProductApiReference).Assembly;
    public static readonly string AssemblyName = typeof(ProductApiReference).Assembly.GetName().Name!;
}