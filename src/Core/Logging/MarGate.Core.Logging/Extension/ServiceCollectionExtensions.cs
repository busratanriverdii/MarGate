using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MarGate.Core.Logging.Extension;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLog(this IServiceCollection services, IHostBuilder hostBuilder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        hostBuilder.UseSerilog(Log.Logger);

        return services;
    }
}
