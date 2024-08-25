using AutoMapper;
using Infrastructures.Messages;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Product.Events.ProductEvents;

namespace Product.Application.UserCases.Product.V1.Events;

internal sealed class UpdatedProductEventHandler : BaseEventHandler<IRepositoryWrapper, UpdatedProductEvent>
{
    public UpdatedProductEventHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public override async Task Handle(UpdatedProductEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}