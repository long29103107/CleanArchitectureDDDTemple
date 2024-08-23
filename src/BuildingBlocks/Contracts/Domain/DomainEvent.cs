using Contracts.Abstractions.Message;

namespace Contracts.Domain;

public abstract class DomainEvent : IDomainEvent
{
    public Guid Id { get; init; }
}