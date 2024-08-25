using FluentValidation;
using Entities = Product.Domain.Entities;

namespace Product.Application.UserCases.Product.V1.Validations;

public class ProductValidator : AbstractValidator<Entities.Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(4);
        RuleFor(p => p.Price).GreaterThan(0);
    }
}