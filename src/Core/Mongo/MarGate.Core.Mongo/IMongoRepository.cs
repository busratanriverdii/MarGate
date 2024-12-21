using System.Linq.Expressions;

namespace MarGate.Core.Mongo;
public interface IMongoRepository<T> : IMongoRepository where T : MongoBaseEntity
{
    public Task AddAsync(T entity, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken= default);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancellationToken = default);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression);
}

public interface IMongoRepository
{
}
