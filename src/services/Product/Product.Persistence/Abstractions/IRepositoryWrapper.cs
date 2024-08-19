using Contracts.Abstractions.Common;
using Microsoft.EntityFrameworkCore;
using Entities = Product.Domain.Entities;

namespace Product.Persistence.Abstractions;

public interface IRepositoryWrapper
{
    public IProductRepository Product { get; }

    DbSet<Entities.Product> Products { get; }
}

