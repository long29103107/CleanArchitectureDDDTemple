using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Entities = Product.Domain.Entities;
using AutoMapper;
using Infrastructures.Messages;
using Serilog;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Command;

namespace Product.Application.UserCases.Product.V1.Commands;

internal sealed class CreateProductCommandHandler : BaseCommandHandler<IRepositoryWrapper, CreateProductCommand, Response.ProductResponse>
{
    public CreateProductCommandHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public override async Task<Result<Response.ProductResponse>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Entities.Product>(command.Request);

        product.Create();

        _repoWrapper.Product.Add(product);

        await _repoWrapper.SaveAsync();

        return Result.Success(_mapper.Map<Response.ProductResponse>(product));
    }
}