using AutoMapper;
using Contracts.Abstractions.Message;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Product.Events.ProductEvents;

namespace Product.Application.UserCases.Product.V1.Events;

internal sealed class DeletedProductEventHandler : IDomainEventHandler<DeletedProductEvent>
{
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DeletedProductEventHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public async Task Handle(DeletedProductEvent notification, CancellationToken cancellationToken)
    {
        _logger.Information($"Product {notification.Product.Id} deleted successfully !");
    }
}