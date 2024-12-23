using MongoDB.Driver;

namespace MarGate.Core.Mongo;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    public MongoDbContext(string connectionString, string databaseName)
    {
        _database = new MongoClient(connectionString).GetDatabase(databaseName);

    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return _database.GetCollection<T>(typeof(T).Name);
    }
}

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>();
}
