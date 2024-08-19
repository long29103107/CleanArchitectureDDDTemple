using System.Reflection;

namespace Package.Shared.Database;
public static class SharedDatabaseReference
{
    public static readonly Assembly Assembly = typeof(SharedDatabaseReference).Assembly;
    public static readonly string AssemblyName = typeof(SharedDatabaseReference).Assembly.GetName().Name!;
}