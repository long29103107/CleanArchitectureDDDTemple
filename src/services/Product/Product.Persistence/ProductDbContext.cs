using Microsoft.EntityFrameworkCore;
using Product.Infrastructure;
using Entities = Product.Domain.Entities;

namespace Product.Persistence;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Entities.Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(ProductPersistenceReference.Assembly);
        base.OnModelCreating(modelBuilder);
    }
}