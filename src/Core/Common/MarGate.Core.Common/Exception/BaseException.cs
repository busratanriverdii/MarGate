namespace MarGate.Core.Common.Exception;

public class BaseException(string message, string code) : System.Exception(message)
{
    public string Code { get; set; } = code;
}
