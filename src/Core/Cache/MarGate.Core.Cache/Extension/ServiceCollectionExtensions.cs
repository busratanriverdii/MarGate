using MarGate.Core.Cache.Distributed;
using MarGate.Core.Cache.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Core.Cache.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            services.AddSingleton<IDistributedCacheService, RedisCacheService>();

            return services;
        }

        public static IServiceCollection AddMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IMemoryCacheService, MemoryCacheService>();

            return services;
        }
    }
}
