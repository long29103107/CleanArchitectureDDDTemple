using Contracts.Domains.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Domain;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }
}