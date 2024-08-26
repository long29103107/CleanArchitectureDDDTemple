using Contracts.Abstractions.Shared;
using Product.Persistence.Repositories.Abstractions;
using Entities = Product.Domain.Entities;
using AutoMapper;
using Infrastructures.BaseHandlers;
using Serilog;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Command;
using FluentValidation;
using Exceptions = Contracts.Domain.Exceptions;
using Product.Domain.Entities;

namespace Product.Application.UserCases.Product.V1.Commands;

internal sealed class CreateProductCommandHandler : BaseCommandHandler<IRepositoryWrapper, CreateProductCommand, Response.ProductResponse>
{
    private readonly IValidator<Entities.Product> _validator;
    public CreateProductCommandHandler(
        IRepositoryWrapper repoWrapper,
        ILogger logger,
        IMapper mapper,
        IValidator<Entities.Product> validator)
        : base(repoWrapper, logger, mapper)
    {
        _validator = validator;
    }

    public override async Task<Result<Response.ProductResponse>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Entities.Product>(command.Request);

        await _ValidateProductAsync(product);

        product.Create();

        _repoWrapper.Product.Add(product);

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