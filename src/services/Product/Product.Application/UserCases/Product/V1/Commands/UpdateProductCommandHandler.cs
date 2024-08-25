using AutoMapper;
using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Infrastructures.Messages;
using Serilog;
using Product.Domain.Product.Exceptions;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Command;

namespace Product.Application.UserCases.Product.V1.Commands;

internal sealed class UpdateProductCommandHandler : BaseCommandHandler<IRepositoryWrapper, UpdateProductCommand, Response.ProductResponse>
{
    public UpdateProductCommandHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper) : base(repoWrapper, logger, mapper)
    {
    }

    public override async Task<Result<Response.ProductResponse>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == command.Id)
            .FirstOrDefaultAsync()
            ?? throw new ProductNotFoundException(command.Id);

        _mapper.Map(command.Request, product);

        product.Update();

        _repoWrapper.Product.Update(product);

        await _repoWrapper.SaveAsync();

        return Result.Success(_mapper.Map<Response.ProductResponse>(product));
    }
}