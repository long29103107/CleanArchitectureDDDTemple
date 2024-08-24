using Contracts.Abstractions.Message;

namespace Product.Domain.Product.Events;

public static class ProductEvents
{
    public record CreatedProductEvent(Entities.Product product) : IDomainEvent;
    public record UpdatedProductEvent(Entities.Product product) : IDomainEvent;
    public record DeletedProductEvent(Entities.Product product) : IDomainEvent;
}