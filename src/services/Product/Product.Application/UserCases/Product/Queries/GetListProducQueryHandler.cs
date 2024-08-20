using Contracts.Abstractions.Shared;
using DistributedSystem.Contract.Abstractions.Message;
using Shared.Dtos.Product;
using static Shared.Services.Product.Query;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Repositories.Abstractions;

namespace Product.Application.UserCases.Product.Queries;

internal sealed class GetListProducQueryHandler : IQueryHandler<GetListProducQuery, List<Response.ProductResponse>>
{
    private readonly IRepositoryWrapper _repoWrapper;

    public GetListProducQueryHandler(IRepositoryWrapper repoWrapper)
    {
        _repoWrapper = repoWrapper;
    }

    public async Task<Result<List<Response.ProductResponse>>> Handle(GetListProducQuery request, CancellationToken cancellationToken)
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