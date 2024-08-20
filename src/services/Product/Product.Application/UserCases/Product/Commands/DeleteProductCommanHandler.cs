using AutoMapper;
using Contracts.Abstractions.Message;
using Contracts.Abstractions.Shared;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Repositories.Abstractions;
using static Shared.Services.Product.Command;

namespace Product.Application.UserCases.Product.Commands;

public class DeleteProductCommanHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IRepositoryWrapper _repoWrapper;

    public DeleteProductCommanHandler(IRepositoryWrapper repoWrapper, IMapper mapper)
    {
        _repoWrapper = repoWrapper;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == request.Id)
            .FirstOrDefaultAsync();

        _repoWrapper.Product.Delete(product);
        await _repoWrapper.SaveAsync();

        return Result.Success();
    }
}