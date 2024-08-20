using Contracts.Abstractions.Shared;
using DistributedSystem.Contract.Abstractions.Message;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Exceptions;
using Product.Persistence.Repositories.Abstractions;
using Shared.Dtos.Product;
using static Shared.Services.Product.Query;

namespace Product.Application.UserCases.Product.Queries;

internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, Response.ProductResponse>
{
    private readonly IRepositoryWrapper _repoWrapper;

    public GetProductQueryHandler(IRepositoryWrapper repoWrapper)
    {
        _repoWrapper = repoWrapper;
    }

    public async Task<Result<Response.ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == request.Id)
            .FirstOrDefaultAsync();
        
        if(product is null)
        {
            throw new ProductNotFoundException(request.Id);
        }    

        var result = new Response.ProductResponse(product.Id, product.Name, product.Price);

        return Result.Success(result);
    }
}