using StackExchange.Redis;
using System.Text.Json;

namespace MarGate.Core.Cache.Distributed;

public class DistributedCacheService(IConnectionMultiplexer redis) : IDistributedCacheService
{
    private readonly IDatabase _database = redis.GetDatabase();

    public async Task<T> GetAsync<T>(string key)
    {
        var json = await _database.StringGetAsync(key);

        return json.HasValue
            ? JsonSerializer.Deserialize<T>(json)
            : default;
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var json = JsonSerializer.Serialize(value);

        return _database.StringSetAsync(key, json, expiration);
    }

    public Task RemoveAsync(string key)
    {
        return _database.KeyDeleteAsync(key);
    }
}

