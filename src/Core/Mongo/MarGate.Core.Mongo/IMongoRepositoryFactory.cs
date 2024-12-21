namespace MarGate.Core.Mongo;

public interface IMongoRepositoryFactory
{ 
    IMongoRepository<T> CreateRepository<T>() where T : MongoBaseEntity;
}

public class MongoRepositoryFactory : IMongoRepositoryFactory
{
    private readonly IMongoDbContext _dbContext;

    public MongoRepositoryFactory(IMongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IMongoRepository<T> CreateRepository<T>() where T : MongoBaseEntity
    {
        return new MongoRepository<T>(_dbContext);
    }
}
