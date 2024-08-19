using Contracts.Abstractions.Shared;
using DistributedSystem.Contract.Abstractions.Message;
using Product.Persistence.Abstractions;
using Shared.Dtos.Product;
using static Shared.Services.Product.Query;
using Microsoft.EntityFrameworkCore;

namespace Product.Application.UserCases.Product.Queries.GetList;

public sealed class GetListProductQuery : IQueryHandler<GetProductsQuery, List<Response.ProductResponse>>
{
    private readonly IRepositoryWrapper _repoWrapper;

    public GetListProductQuery(IRepositoryWrapper repoWrapper)
    {
        _repoWrapper = repoWrapper;
    }

    public async Task<Result<List<Response.ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repoWrapper.Product.FindAll().ToListAsync();
        var result = new List<Response.ProductResponse>();

        foreach (var item in products)
        { 
            result.Add(new Response.ProductResponse(item.Id, item.Name, item.Price));
        }
        return Result.Success(result);
    }
}