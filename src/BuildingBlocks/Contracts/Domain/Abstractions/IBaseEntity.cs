namespace Contracts.Domains.Interfaces;

public interface IBaseEntity<T>
{
    T Id { get; set; }
}
