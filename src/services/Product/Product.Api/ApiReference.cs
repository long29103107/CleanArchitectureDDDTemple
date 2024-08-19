using System.Reflection;

namespace Product.Api;
public static class ApiReference
{
    public static readonly Assembly Assembly = typeof(ApiReference).Assembly;
    public static readonly string AssemblyName = typeof(ApiReference).Assembly.GetName().Name!;
}