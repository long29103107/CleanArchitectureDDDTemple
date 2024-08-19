using System.Reflection;

namespace Product.Presentation;
public static class PresentationReference
{
    public static readonly Assembly Assembly = typeof(PresentationReference).Assembly;
    public static readonly string AssemblyName = typeof(PresentationReference).Assembly.GetName().Name!;
}