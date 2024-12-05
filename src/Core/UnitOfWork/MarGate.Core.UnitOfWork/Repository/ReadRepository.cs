using MarGate.Core.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarGate.Core.Persistence.Repository;
public class ReadRepository<T>(ReadDbContext context) : IReadRepository<T> where T : class
{
    public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AsNoTracking().AnyAsync(expression);
    }

    public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AsNoTracking();
    }
}
