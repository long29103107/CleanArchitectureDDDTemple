using System.Reflection;

namespace Contracts;

public static class ContractsReference
{
    public static readonly Assembly Assembly = typeof(ContractsReference).Assembly;
    public static readonly string AssemblyName = typeof(ContractsReference).Assembly.GetName().Name!;
}