using MarGate.Core.Cache.Distributed;
using MarGate.Core.Cache.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MarGate.Core.Cache.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            services.AddSingleton<IDistributedCacheService, DistributedCacheService>();

            services.AddMemoryCache();
            services.AddSingleton<IMemoryCacheService, MemoryCacheService>();

            return services;
        }
    }
}
