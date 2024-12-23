using System.Linq.Expressions;

namespace MarGate.Core.UnitOfWork.Repository;
public interface IBaseRepository<T> : IBaseRepository where T : class
{
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancellationToken = default);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}

public interface IBaseRepository
{
}
