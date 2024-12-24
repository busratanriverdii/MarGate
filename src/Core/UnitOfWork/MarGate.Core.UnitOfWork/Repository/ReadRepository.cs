using MarGate.Core.DDD;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarGate.Core.UnitOfWork.Repository;
public class ReadRepository<T>(DbContext context) : IReadRepository<T> where T : BaseEntity
{
    public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancelationToken = default)
    {
        if (expression == null)
        {
            return context.Set<T>().AsNoTracking().ToListAsync();
        }

        return context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().AsNoTracking().AnyAsync(expression);
    }

    public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().AsNoTracking();
    }
}
