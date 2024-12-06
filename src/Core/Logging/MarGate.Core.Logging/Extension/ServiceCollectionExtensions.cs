using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.ComponentModel;

namespace MarGate.Core.Logging.Extension;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLog(this IServiceCollection services, LoggingOptions options, IHostBuilder hostBuilder)
    {
        var loggerConfiguration = new LoggerConfiguration().MinimumLevel.Information();
        SetWriteToConfiguration(loggerConfiguration, options.WriteToType);
        Log.Logger = loggerConfiguration.CreateLogger();

        hostBuilder.UseSerilog(Log.Logger);

        return services;
    }

    private static void SetWriteToConfiguration(LoggerConfiguration loggerConfiguration, WriteToType writeToType)
    {
        switch (writeToType)
        {
            case WriteToType.Console:
                loggerConfiguration.WriteTo.Console();
                break;
            default:
                throw new InvalidEnumArgumentException(nameof(WriteToType));
        }
    }
}

public class LoggingOptions
{
    public WriteToType WriteToType { get; set; }
}

public enum WriteToType
{
    Console,
}
