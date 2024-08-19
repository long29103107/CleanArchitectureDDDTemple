using Entities = Product.Domain.Entities;
using Shared.Domain.ValueOf;
using Contracts.Abstractions.Common;

namespace Product.Persistence.Abstractions;

public interface IProductRepository : IRepositoryBase<Entities.Product, ProductDbContext>
{
}