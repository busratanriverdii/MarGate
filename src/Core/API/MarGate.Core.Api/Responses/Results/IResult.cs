namespace MarGate.Core.Api.Responses.Results;

public interface IResult<out T>
{
    T Data { get; }
    string? Message { get; }
    ResultStatus ResultStatus { get; }
}
