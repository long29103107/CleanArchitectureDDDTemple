using System.Reflection;

namespace Infrastructures;

public static class InfrastructuresReference
{
    public static readonly Assembly Assembly = typeof(InfrastructuresReference).Assembly;
    public static readonly string AssemblyName = typeof(InfrastructuresReference).Assembly.GetName().Name!;
}