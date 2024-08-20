using Contracts.Abstractions.Common;
using Microsoft.EntityFrameworkCore;
using Entities = Product.Domain.Entities;

namespace Product.Persistence.Repositories.Abstractions;

public interface IRepositoryWrapper : IUnitOfWork<ProductDbContext>
{
    public IProductRepository Product { get; }

    DbSet<Entities.Product> Products { get; }
}

