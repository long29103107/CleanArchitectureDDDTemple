using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Shared.Dtos.Product;
using Entities = Product.Domain.Entities;
using static Shared.Services.Product.Command;
using AutoMapper;
using static Product.Domain.Product.Events.ProductEvents;
using Infrastructures.Messages;
using Serilog;

namespace Product.Application.UserCases.Product.Commands;

internal sealed class CreateProductCommandHandler : BaseCommandHandler<IRepositoryWrapper, CreateProductCommand, Response.ProductResponse>
{
    public CreateProductCommandHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public override async Task<Result<Response.ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Entities.Product>(request);

        product.Create();

        _repoWrapper.Product.Add(product);

        await _repoWrapper.SaveAsync();

        return Result.Success(_mapper.Map<Response.ProductResponse>(product));
    }
}