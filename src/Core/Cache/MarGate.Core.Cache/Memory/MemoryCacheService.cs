namespace MarGate.Core.Cache.Memory;

public class MemoryCacheService(IMemoryCacheService memoryCacheService) : IMemoryCacheService
{
    public Task<T> GetAsync<T>(string key)
    {
        return memoryCacheService.GetAsync<T>(key);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        return memoryCacheService.SetAsync(key, value, expiration);
    }

    public Task RemoveAsync(string key)
    {
        return memoryCacheService.RemoveAsync(key);
    }
}

