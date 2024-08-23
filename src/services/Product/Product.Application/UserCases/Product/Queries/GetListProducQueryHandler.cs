using Contracts.Abstractions.Shared;
using Shared.Dtos.Product;
using static Shared.Services.Product.Query;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Repositories.Abstractions;
using Infrastructures.Messages;
using AutoMapper;
using Serilog;

namespace Product.Application.UserCases.Product.Queries;

internal sealed class GetListProducQueryHandler : BaseQueryHandler<IRepositoryWrapper, GetListProducQuery, List<Response.ProductResponse>>
{
    public GetListProducQueryHandler(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger) : base(repoWrapper, mapper, logger)
    {
    }

    public override async Task<Result<List<Response.ProductResponse>>> Handle(GetListProducQuery request, CancellationToken cancellationToken)
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