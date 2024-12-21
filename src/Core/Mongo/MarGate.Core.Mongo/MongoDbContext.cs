using MongoDB.Driver;

namespace MarGate.Core.Mongo;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    public MongoDbContext()
    {
        _database = new MongoClient("").GetDatabase("");

    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return _database.GetCollection<T>(nameof(T));
    }
}

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>();
}
