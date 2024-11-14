namespace MarGate.Core.Common.Exception;

public class BusinessException(string code, string message) : BaseException(code, message)
{
}
