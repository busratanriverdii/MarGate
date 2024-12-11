using MarGate.Core.Logging.Configuration;
using Serilog.Events;

namespace MarGate.Core.Logging.LogTargets;

public class FileLogSettings : ILogTargetSettings
{
    public string FilePath { get; set; } = "logs/app.log";
    public bool RollOnFileSizeLimit { get; set; } = true;
    public long MaxFileSizeBytes { get; set; } = 10485760;
    public LogEventLevel LogLevel { get; set; } = LogEventLevel.Information;

}
