using MarGate.Core.Logging.LogTargets;

namespace MarGate.Core.Logging.Configuration;

public class LoggingOptions
{
    public ILogTargetSettings LogTargetSettings { get; set; } = new ConsoleLogSettings();
}
