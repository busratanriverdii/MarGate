using System.Linq.Expressions;

namespace MarGate.Core.Persistence.Repository;
public interface IBaseRepository<T> : IBaseRepository where T : class
{
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
    IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression);
}

public interface IBaseRepository
{
}
