using System.Reflection;

namespace Product.Infrastructure;
public static class PersistenceReference
{
    public static readonly Assembly Assembly = typeof(PersistenceReference).Assembly;
    public static readonly string AssemblyName = typeof(PersistenceReference).Assembly.GetName().Name!;
}