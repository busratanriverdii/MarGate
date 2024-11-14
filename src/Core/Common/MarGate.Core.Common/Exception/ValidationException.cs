namespace MarGate.Core.Common.Exception;

public class ValidationException(string code, string message) : BaseException(code, message)
{
}
