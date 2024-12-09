using MarGate.Core.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarGate.Core.Persistence.Repository;
public class WriteRepository<T>(WriteDbContext context) : IWriteRepository<T> where T : class
{
    public async Task CreateAsync(T model)
    {
        await context.Set<T>().AddAsync(model);
    }

    public void Delete(T model)
    {
        context.Set<T>().Remove(model);
    }

    public void Update(T model)
    {
        context.Set<T>().Update(model);
    }

    public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Where(expression).ToListAsync();
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().SingleOrDefaultAsync(expression);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().AnyAsync(expression);
    }

    public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>();
    }
}

