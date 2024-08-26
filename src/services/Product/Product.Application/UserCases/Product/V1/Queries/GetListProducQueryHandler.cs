using Contracts.Abstractions.Shared;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Serilog;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Query;
using DistributedSystem.Contract.Abstractions.Message;
using Product.Persistence.Repositories.Abstractions;

namespace Product.Application.UserCases.Product.V1.Queries;

internal sealed class GetListProducQueryHandler : IQueryHandler<GetListProducQuery, List<Response.ProductResponse>>
{
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetListProducQueryHandler(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
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