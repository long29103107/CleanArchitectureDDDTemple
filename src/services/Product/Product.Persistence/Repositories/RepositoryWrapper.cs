using Contracts.Abstractions.Common;
using Infrastructures.Common;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Repositories.Abstractions;

namespace Product.Persistence.Repositories;

public class RepositoryWrapper : UnitOfWork<ProductDbContext>, IRepositoryWrapper
{
    private readonly ProductDbContext _context;
    private readonly IUnitOfWork<ProductDbContext> _unitOfwork;

    public RepositoryWrapper(ProductDbContext context, IUnitOfWork<ProductDbContext> unitOfwork) : base(context)
    {
        _context = context;
        _unitOfwork = unitOfwork;
    }

    private IProductRepository _product;
    public IProductRepository Product
    {
        get
        {
            if(_product == null)
            {
                _product = new ProductRepository(_context, _unitOfwork);
            }
            return _product;
        }
    }

    public DbSet<Domain.Entities.Product> Products { get; }
}