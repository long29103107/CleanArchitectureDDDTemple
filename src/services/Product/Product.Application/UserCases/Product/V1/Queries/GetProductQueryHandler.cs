﻿using AutoMapper;
using Contracts.Abstractions.Shared;
using DistributedSystem.Contract.Abstractions.Message;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Product.Exceptions;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Query;

namespace Product.Application.UserCases.Product.V1.Queries;

internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, Response.ProductResponse>
{
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetProductQueryHandler(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public async Task<Result<Response.ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == request.Id)
            .FirstOrDefaultAsync()
            ?? throw new ProductNotFoundException(request.Id);

        var result = new Response.ProductResponse(product.Id, product.Name, product.Price);

        return Result.Success(result);
    }
}