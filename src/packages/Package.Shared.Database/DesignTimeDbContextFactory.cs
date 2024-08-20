using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Package.Shared.Database;

namespace MyBlog.Shared.Databases;

public class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T> where T : DbContext
{
    protected virtual string _dbConnStrKey { get; set; } = "DefaultConnection";

    public T CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        Console.WriteLine(Directory.GetCurrentDirectory() + " " + typeof(T).FullName + " " + _dbConnStrKey);
        var connectionString = configuration.GetConnectionString(_dbConnStrKey);
        Console.WriteLine(connectionString);

        var builder = new DbContextOptionsBuilder<T>();       
        builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(SharedDatabaseReference.AssemblyName));
        var dbContext = (T)Activator.CreateInstance(typeof(T), builder.Options);
        return dbContext;
    }
}