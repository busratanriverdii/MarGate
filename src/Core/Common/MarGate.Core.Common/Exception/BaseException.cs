namespace MarGate.Core.Common.Exception;

public class BaseException(string code, string message) : System.Exception(message)
{
    public string Code { get; set; } = code;
}
