using Contracts.Abstractions.Message;
using Serilog;
using AutoMapper;

namespace Infrastructures.BaseHandlers;

public abstract class BaseEventHandler<TRepositoryWrapper, TEvent> : IDomainEventHandler<TEvent>
    where TEvent : IDomainEvent
{
    protected readonly TRepositoryWrapper _repoWrapper;
    protected readonly IMapper _mapper;
    protected readonly ILogger _logger;

    public BaseEventHandler(TRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public virtual async Task Handle(TEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
