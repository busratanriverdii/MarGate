using Microsoft.Extensions.Caching.Memory;

namespace MarGate.Core.Cache.Memory;

public class MemoryCacheService(IMemoryCache memoryCache) : IMemoryCacheService
{
    public Task<T> GetAsync<T>(string key)
    {
        return Task.FromResult(memoryCache.Get<T>(key));
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        return Task.FromResult(memoryCache.Set(key, value, expiration));
    }

    public Task RemoveAsync(string key)
    {
        memoryCache.Remove(key);
        return Task.CompletedTask;
    }
}

