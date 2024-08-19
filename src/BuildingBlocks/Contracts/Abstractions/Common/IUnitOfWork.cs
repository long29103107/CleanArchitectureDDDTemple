using Microsoft.EntityFrameworkCore;

namespace Contracts.Abstractions.Common;

public interface IUnitOfWork<TContext> : IDisposable
    where TContext : DbContext
{
    Task<int> CommitAsync();
    Task SaveChangeAsync();
}
