﻿using Contracts.Abstractions.Message;

namespace Product.Domain.Product.Events;

public static class ProductEvents
{
    public sealed record CreatedProductEvent(Entities.Product product) : IDomainEvent;
    public sealed record UpdatedProductEvent(Entities.Product product) : IDomainEvent;
    public sealed record DeletedProductEvent(Entities.Product product) : IDomainEvent;
}