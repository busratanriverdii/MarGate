using MarGate.Core.Api.Responses.Results;
using Microsoft.AspNetCore.Mvc;

namespace MarGate.Core.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected static Result<T> ApiResponse<T>(T response)
    {
        return new Result<T>(ResultStatus.Success, response);
    }
}

public class ApiResponse
{
    public int StatusCode { get; set; }
    public object Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
}

