using AutoMapper;
using Contracts.Abstractions.Message;
using Infrastructures.Messages;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Events.ProductEvents;

namespace Product.Application.UserCases.Product.Events;

internal sealed class UpdatedProductEventHandler : BaseEventHandler<IRepositoryWrapper, UpdatedProductEvent>
{
    public UpdatedProductEventHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public async Task Handle(UpdatedProductEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}