using Contracts.Abstractions.Message;
using Serilog;
using AutoMapper;

namespace Infrastructures.Messages;

public abstract class BaseEventHandler<TRepositoryWrapper, TEvent> : IDomainEventHandler<TEvent>
    where TEvent : IDomainEvent
{
    protected readonly TRepositoryWrapper _repoWrapper;
    protected readonly IMapper _mapper;
    protected readonly ILogger _logger;

    public BaseEventHandler(TRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper)
    {
        _repoWrapper = repoWrapper;
        _logger = logger;
        _mapper = mapper;
    }

    public virtual async Task Handle(TEvent request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
