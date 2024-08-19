using System.Reflection;

namespace Product.Application;
public static class ApplicationReference
{
    public static readonly Assembly Assembly = typeof(ApplicationReference).Assembly;
    public static readonly string AssemblyName = typeof(ApplicationReference).Assembly.GetName().Name!;
}