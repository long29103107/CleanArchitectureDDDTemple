using AutoMapper;
using Contracts.Abstractions.Shared;
using Infrastructures.Messages;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Product.Exceptions;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Shared.Services.Product.V1.Command;

namespace Product.Application.UserCases.Product.V1.Commands;

internal sealed class DeleteProductCommanHandler : BaseCommandHandler<IRepositoryWrapper, DeleteProductCommand>
{
    public DeleteProductCommanHandler(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger) : base(repoWrapper, mapper, logger)
    {
    }

    public override async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == command.Id)
            .FirstOrDefaultAsync()
            ?? throw new ProductNotFoundException(command.Id);

        product.Delete();

        _repoWrapper.Product.Remove(product);

        await _repoWrapper.SaveAsync();

        return Result.Success();
    }
}