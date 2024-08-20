using Contracts.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Contracts.Abstractions.Common;

namespace Infrastructures.Common;

public class RepositoryBase<T, TContext> : IRepositoryBase<T, TContext>
    where T : class
    where TContext : DbContext
{
    protected readonly TContext _context;
    protected readonly IUnitOfWork<TContext> _unitOfWork;

    public RepositoryBase(TContext context, IUnitOfWork<TContext> unitOfWork)
    {
        _context = context ?? throw new ArgumentNullException(nameof(_context));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
    }

    #region Filter
    public virtual IQueryable<T> Filter()
    {
        return _context.Set<T>();
    }
    #endregion

    #region Query
    public IQueryable<T> FindAll(bool isTracking = false)
    {
        if (isTracking)
        {
            return Filter();
        }

        return Filter().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        if (isTracking)
        {
            return Filter().Where(expression);
        }

        return Filter().AsNoTracking().Where(expression);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>>[] expressions, bool isTracking = false)
    {
        var queryable = Filter();

        if (!isTracking)
        {
            queryable = queryable.AsNoTracking();
        }

        foreach (var expression in expressions)
        {
            queryable = queryable.Where(expression);
        }

        return queryable;
    }
    #endregion

    #region Action
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    public void UpdateRange(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        if (entities == null)
            return;

        _context.Set<T>().RemoveRange(entities);
    }
    #endregion

    #region Transaction
    public Task<int> SaveChangesAsync()
    {
        return _unitOfWork.CommitAsync();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync();
    }

    public async Task EndTransactionAsync()
    {
        await SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    #endregion

    #region Linq 
    public bool Any()
    {
        return Filter().Any();
    }
    public async Task<bool> AnyAsync()
    {
        return await Filter().AnyAsync();
    }
    #endregion
}
