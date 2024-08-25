using AutoMapper;
using Infrastructures.Messages;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Product.Events.ProductEvents;

namespace Product.Application.UserCases.Product.V1.Events;

internal sealed class CreatedProductEventHandler : BaseEventHandler<IRepositoryWrapper, CreatedProductEvent>
{
    public CreatedProductEventHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public override async Task Handle(CreatedProductEvent notification, CancellationToken cancellationToken)
    {
        _logger.Information($"Product {notification.Product.Id} created successfully !");
    }
}