using MarGate.Identity.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Identity.Application.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }
    }
}
