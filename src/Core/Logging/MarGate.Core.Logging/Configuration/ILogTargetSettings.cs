using Serilog.Events;

namespace MarGate.Core.Logging.Configuration;

public interface ILogTargetSettings
{
    public LogEventLevel LogLevel { get; set; }

}

