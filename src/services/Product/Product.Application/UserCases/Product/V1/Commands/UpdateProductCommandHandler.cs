using AutoMapper;
using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Product.Domain.Product.Exceptions;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Command;
using Entities = Product.Domain.Entities;
using FluentValidation;
using Exceptions = Contracts.Domain.Exceptions;
using Contracts.Abstractions.Message;

namespace Product.Application.UserCases.Product.V1.Commands;

internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Response.ProductResponse>
{
    private readonly IValidator<Domain.Entities.Product> _validator;
    private readonly IRepositoryWrapper _repoWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UpdateProductCommandHandler(IRepositoryWrapper repoWrapper, ILogger logger, IMapper mapper, IValidator<Entities.Product> validator)
    {
        _repoWrapper = repoWrapper ?? throw new ArgumentNullException(nameof(_repoWrapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
    }

    public async Task<Result<Response.ProductResponse>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repoWrapper.Product
            .FindByCondition(x => x.Id == command.Id)
            .FirstOrDefaultAsync()
            ?? throw new ProductNotFoundException(command.Id);

        _mapper.Map(command.Request, product);

        await _ValidateProductAsync(product);

        product.Update();

        _repoWrapper.Product.Update(product);

        await _repoWrapper.SaveAsync();

        return Result.Success(_mapper.Map<Response.ProductResponse>(product));
    }

    private async Task _ValidateProductAsync(Entities.Product product)
    {
        var validatedResult = await _validator.ValidateAsync(product);

        if (!validatedResult.IsValid)
        {
            var errors = validatedResult.Errors
                .Select(x => new Exceptions.ValidationError(x.PropertyName, x.ErrorMessage))
                .ToList();

            throw new Exceptions.ValidationException(errors);
        }
    }
}