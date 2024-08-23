using Contracts.Domains.Interfaces;

namespace Contracts.Domain.Abstractions;

public interface IAuditEntity<T> : IDateTracking, IUserTracking, IBaseEntity<T>
{
}

