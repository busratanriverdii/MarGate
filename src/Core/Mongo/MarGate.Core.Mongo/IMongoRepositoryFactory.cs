namespace MarGate.Core.Mongo;

public interface IMongoRepositoryFactory
{ 
    IMongoRepository<T> CreateRepository<T>() where T : MongoBaseEntity;
}

public class MongoRepositoryFactory(IMongoDbContext dbContext) : IMongoRepositoryFactory
{
    public IMongoRepository<T> CreateRepository<T>() where T : MongoBaseEntity
    {
        return new MongoRepository<T>(dbContext);
    }
}
