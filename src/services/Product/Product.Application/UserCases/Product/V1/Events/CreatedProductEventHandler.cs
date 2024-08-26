using AutoMapper;
using Contracts.Abstractions.Message;
using FluentValidation;
using Infrastructures.BaseHandlers;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Product.Events.ProductEvents;

namespace Product.Application.UserCases.Product.V1.Events;

internal sealed class CreatedProductEventHandler : IDomainEventHandler<CreatedProductEvent>
{
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreatedProductEventHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }

    public async Task Handle(CreatedProductEvent notification, CancellationToken cancellationToken)
    {
        _logger.Information($"Product {notification.Product.Id} created successfully !");
    }
}