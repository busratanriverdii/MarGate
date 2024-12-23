namespace MarGate.Core.Api.Responses.Results;

public class Result<T> : IResult<T>
{
    public Result(ResultStatus resultStatus, T data)
    {
        ResultStatus = resultStatus;
        Data = data ?? throw new ArgumentNullException(nameof(data)); 
    }

    public Result(ResultStatus resultStatus, string message)
    {
        ResultStatus = resultStatus;
        Message = message;
    }

    public Result(ResultStatus resultStatus, string message, T data)
    {
        ResultStatus = resultStatus;
        Message = message;
        Data = data ?? throw new ArgumentNullException(nameof(data)); 
    }

    public T Data { get; }
    public string? Message { get; }
    public ResultStatus ResultStatus { get; }

    public static Result<T> Success(T data)
    {
        return new Result<T>(ResultStatus.Success, data);
    }

    public static Result<T> Error(string message)
    {
        return new Result<T>(ResultStatus.Error, message);
    }
}

