using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace MarGate.Core.Mongo;

public class MongoRepository<T> : IMongoRepository<T> where T : MongoBaseEntity
{
    private readonly IMongoCollection<T> collection;
    public MongoRepository(IMongoDbContext mongoDbContext)
    {
        this.collection = mongoDbContext.GetCollection<T>();
    }

    public Task AddAsync(T entity, CancellationToken cancellationToken= default)
    {
        return collection.InsertOneAsync(entity, new InsertOneOptions(), cancellationToken);
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken= default)
    {
        return collection.DeleteOneAsync(Builders<T>.Filter.Eq(nameof(entity.Id), entity.Id), cancellationToken);
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return collection.AsQueryable().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> expression)
    {
        return collection.AsQueryable();
    }

    public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression = null, CancellationToken cancellationToken = default)
    {
        if(expression == null)
        {
            return collection.AsQueryable().ToListAsync(cancellationToken);
        }

        return collection.AsQueryable().Where(expression).ToListAsync(cancellationToken);
    }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return collection.AsQueryable().SingleOrDefaultAsync(expression, cancellationToken);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return collection.ReplaceOneAsync(Builders<T>.Filter.Eq(nameof(entity.Id), entity.Id), entity, cancellationToken: cancellationToken);
    }
}
