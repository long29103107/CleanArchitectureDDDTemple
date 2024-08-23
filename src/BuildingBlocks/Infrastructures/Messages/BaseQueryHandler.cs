using AutoMapper;
using Contracts.Abstractions.Shared;
using DistributedSystem.Contract.Abstractions.Message;
using Serilog;
using System;

namespace Infrastructures.Messages;

public abstract class BaseQueryHandler<TRepositoryWrapper, TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    protected readonly TRepositoryWrapper _repoWrapper;
    protected readonly IMapper _mapper;
    protected readonly ILogger _logger;

    public BaseQueryHandler(TRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public virtual async Task<Result<TResponse>> Handle(TQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
