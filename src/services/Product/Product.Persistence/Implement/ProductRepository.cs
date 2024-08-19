
using Contracts.Abstractions.Common;
using Infrastructures.Common;
using Product.Persistence.Abstractions;
using Entities = Product.Domain.Entities;

namespace Product.Persistence.Implement;

public class ProductRepository : RepositoryBase<Entities.Product, ProductDbContext>, IProductRepository
{
    public ProductRepository(ProductDbContext context, IUnitOfWork<ProductDbContext> unitOfWork) : base(context, unitOfWork)
    {
    }
}