using MarGate.Order.Application.RemoteCall;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Order.Application.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityRemoteCall, IdentityRemoteCall>();

            return services;
        }
    }
}
