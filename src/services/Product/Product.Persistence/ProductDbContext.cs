using Microsoft.EntityFrameworkCore;
using Entities = Product.Domain.Entities;

namespace Product.Persistence;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public virtual DbSet<Entities.Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(ProductPersistenceReference.Assembly);
        base.OnModelCreating(modelBuilder);
    }
}