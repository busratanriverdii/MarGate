using Elastic.Serilog.Sinks;
using Elastic.Transport;
using MarGate.Core.Logging.Configuration;
using MarGate.Core.Logging.LogTargets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MarGate.Core.Logging.Extension;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLog(this IServiceCollection services, ILoggingBuilder loggingBuilder, LoggingOptions options = null)
    {
        options ??= new LoggingOptions();

        loggingBuilder.ClearProviders();

        Log.Logger = ConfigureLoggerConfiguration(options.LogTargetSettings)
            .CreateLogger();

        services.AddSingleton(Log.Logger);

        services.AddLogging();

        return services;
    }

    private static LoggerConfiguration ConfigureLoggerConfiguration(ILogTargetSettings logTargetSettings)
    {
        var loggerConfiguration = new LoggerConfiguration();

        switch (logTargetSettings)
        {
            case ConsoleLogSettings consoleLogSettings:
                WriteToConsole(loggerConfiguration, consoleLogSettings);
                break;

            case FileLogSettings fileSettings when !string.IsNullOrEmpty(fileSettings.FilePath):
                break;

            case ElasticsearchLogSettings elasticSearchSettings when !string.IsNullOrEmpty(elasticSearchSettings.ElasticsearchUrl):
                WriteToElastic(loggerConfiguration, elasticSearchSettings);
                break;
            default:
                throw new InvalidOperationException($"{logTargetSettings.GetType().Name}");
        }

        return loggerConfiguration;
    }

    private static void WriteToConsole(LoggerConfiguration loggerConfiguration, ConsoleLogSettings consoleLogSettings)
    {
        loggerConfiguration.WriteTo.Console(
            consoleLogSettings.LogFormatter,
            consoleLogSettings.LogLevel);
    }

    private static void WriteToFile(LoggerConfiguration loggerConfiguration, FileLogSettings fileSettings)
    {
        loggerConfiguration.WriteTo.File(
            fileSettings.FilePath,
            restrictedToMinimumLevel: fileSettings.LogLevel,
            fileSizeLimitBytes: fileSettings.MaxFileSizeBytes,
            rollOnFileSizeLimit: fileSettings.RollOnFileSizeLimit);
    }

    private static void WriteToElastic(LoggerConfiguration loggerConfiguration, ElasticsearchLogSettings elasticSearchSettings)
    {
        loggerConfiguration.WriteTo.Elasticsearch([new Uri(elasticSearchSettings.ElasticsearchUrl)], configureOptions: x =>
        {
            x.DataStream = new Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName(elasticSearchSettings.IndexName);
            x.BootstrapMethod = Elastic.Ingest.Elasticsearch.BootstrapMethod.Failure; 
        },
        restrictedToMinimumLevel: elasticSearchSettings.LogLevel, configureTransport: x =>
        {
            x.Authentication(new BasicAuthentication(elasticSearchSettings.UserName, elasticSearchSettings.Password));
        });
    }
}
