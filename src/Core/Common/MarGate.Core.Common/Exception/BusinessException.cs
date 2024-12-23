namespace MarGate.Core.Common.Exception;

public class BusinessException(string message, string code) : BaseException(message, code)
{
}
