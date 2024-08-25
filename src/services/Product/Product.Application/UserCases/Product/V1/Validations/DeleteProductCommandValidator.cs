using FluentValidation;
using static Shared.Services.Product.V1.Command;

namespace Product.Application.UserCases.Product.V1.Validations;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0)
            .WithMessage("Product must be geater than 0");
    }
}