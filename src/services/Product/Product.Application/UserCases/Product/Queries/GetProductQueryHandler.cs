using AutoMapper;
using Contracts.Abstractions.Shared;
using Infrastructures.Messages;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Product.Exceptions;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using Shared.Dtos.Product;
using static Shared.Services.Product.Query;

namespace Product.Application.UserCases.Product.Queries;

internal sealed class GetProductQueryHandler : BaseQueryHandler<IRepositoryWrapper, GetProductQuery, Response.ProductResponse>
{
    public GetProductQueryHandler(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger) : base(repoWrapper, mapper, logger)
    {
    }

    public override async Task<Result<Response.ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
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