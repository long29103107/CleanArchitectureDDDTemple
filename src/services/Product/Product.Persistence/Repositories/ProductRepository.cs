
using Contracts.Abstractions.Common;
using Infrastructures.Common;
using Product.Persistence.Repositories.Abstractions;
using Entities = Product.Domain.Entities;

namespace Product.Persistence.Repositories;

public class ProductRepository : RepositoryBase<Entities.Product, ProductDbContext>, IProductRepository
{
    public ProductRepository(ProductDbContext context, IUnitOfWork<ProductDbContext> unitOfWork) : base(context, unitOfWork)
    {
    }
}