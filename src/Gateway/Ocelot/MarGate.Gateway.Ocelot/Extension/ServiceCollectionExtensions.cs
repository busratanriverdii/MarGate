using Ocelot.DependencyInjection;

namespace MarGate.Gateway.Ocelot.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOcelotGateway(this IServiceCollection services)
    {
        services.AddOcelot();

        return services;
    }
}
