using MarGate.Core.DDD;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarGate.Core.Persistence.Repository;
public class WriteRepository<T>(DbContext context) : IWriteRepository<T> where T : BaseEntity
{
    public long Create(T model)
    {
        context.Set<T>().Add(model);
        return model.Id;
    }

    public bool Delete(T model)
    {
        context.Set<T>().Remove(model);

        return true;
    }

    public bool Update(T model)
    {
        context.Set<T>().Update(model);

        return true;
    }

    public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().Where(expression).ToListAsync();
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().SingleOrDefaultAsync(expression);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>().AnyAsync(expression);
    }

    public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
    {
        return context.Set<T>();
    }
}

