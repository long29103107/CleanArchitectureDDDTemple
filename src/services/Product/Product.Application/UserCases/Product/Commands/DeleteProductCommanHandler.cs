using AutoMapper;
using Contracts.Abstractions.Shared;
using Infrastructures.Messages;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Product.Exceptions;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Product.Domain.Product.Events.ProductEvents;
using static Shared.Services.Product.Command;
using Entities = Product.Domain.Entities; 

namespace Product.Application.UserCases.Product.Commands;

public class DeleteProductCommanHandler : BaseCommandHandler<IRepositoryWrapper, DeleteProductCommand>
{
    public DeleteProductCommanHandler(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger logger) : base(repoWrapper, mapper, logger)
    {
    }

    public override async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == request.Id)
            .FirstOrDefaultAsync()
            ?? throw new ProductNotFoundException(request.Id);

        product.Delete();

        _repoWrapper.Product.Delete(product);

        await _repoWrapper.SaveAsync();

        return Result.Success();
    }
}