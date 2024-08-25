using Contracts.Abstractions.Message;

namespace Product.Domain.Product.Events;

public static class ProductEvents
{
    public sealed record CreatedProductEvent(Entities.Product Product) : IDomainEvent;
    public sealed record UpdatedProductEvent(Entities.Product Product) : IDomainEvent;
    public sealed record DeletedProductEvent(Entities.Product Product) : IDomainEvent;
}