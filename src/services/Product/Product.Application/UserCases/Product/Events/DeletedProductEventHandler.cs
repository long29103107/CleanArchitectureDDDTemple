using AutoMapper;
using Contracts.Abstractions.Message;
using Infrastructures.Messages;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Events.ProductEvents;

namespace Product.Application.UserCases.Product.Events;

internal sealed class DeletedProductEventHandler : BaseEventHandler<IRepositoryWrapper, DeletedProductEvent>
{
    public DeletedProductEventHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public override async Task Handle(DeletedProductEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}