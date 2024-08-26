using AutoMapper;
using Contracts.Abstractions.Message;
using Contracts.Abstractions.Shared;
using FluentValidation;
using Infrastructures.BaseHandlers;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Product.Exceptions;
using Product.Persistence.Repositories.Abstractions;
using Serilog;
using static Shared.Services.Product.V1.Command;
using Entities = Product.Domain.Entities;

namespace Product.Application.UserCases.Product.V1.Commands;

internal sealed class DeleteProductCommanHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IValidator<Domain.Entities.Product> _validator;
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DeleteProductCommanHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper, IValidator<Entities.Product> validator)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
    }

    public async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
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