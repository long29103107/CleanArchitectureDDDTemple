using Entities = Product.Domain.Entities;
using Contracts.Abstractions.Common;

namespace Product.Persistence.Repositories.Abstractions;

public interface IProductRepository : IRepositoryBase<Entities.Product, ProductDbContext>
{
}