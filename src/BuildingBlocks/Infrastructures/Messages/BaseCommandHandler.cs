using AutoMapper;
using Contracts.Abstractions.Message;
using Contracts.Abstractions.Shared;
using Serilog;

namespace Infrastructures.Messages;

public abstract class BaseCommandHandler<TRepositoryWrapper, TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    protected readonly TRepositoryWrapper _repoWrapper;
    protected readonly IMapper _mapper;
    protected readonly ILogger _logger;

    public BaseCommandHandler(TRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger)
    {
        _repoWrapper = repoWrapper;
        _mapper = mapper;
        _logger = logger;
    }

    public virtual async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public abstract class BaseCommandHandler<TRepositoryWrapper, TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    protected readonly TRepositoryWrapper _repoWrapper;
    protected readonly IMapper _mapper;
    protected readonly ILogger _logger;

    public BaseCommandHandler(TRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public virtual async Task<Result<TResponse>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
