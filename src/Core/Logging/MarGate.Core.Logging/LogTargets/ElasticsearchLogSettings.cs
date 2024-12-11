using MarGate.Core.Logging.Configuration;
using Serilog.Events;

namespace MarGate.Core.Logging.LogTargets;

public class ElasticsearchLogSettings : ILogTargetSettings
{
    public string ElasticsearchUrl { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string IndexName { get; set; } = "logs";
    public LogEventLevel LogLevel { get; set; } = LogEventLevel.Information;
}
