using System.Reflection;

namespace Product.Presentation;
public static class ProductPresentationReference
{
    public static readonly Assembly Assembly = typeof(ProductPresentationReference).Assembly;
    public static readonly string AssemblyName = typeof(ProductPresentationReference).Assembly.GetName().Name!;
}