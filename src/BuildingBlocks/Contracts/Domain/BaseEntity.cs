using Contracts.Domains.Interfaces;

namespace Contracts.Domain;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
{
    public TKey Id { get; set; }
}