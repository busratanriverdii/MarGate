namespace MarGate.Core.Api.Responses.Results;

public enum ResultStatus
{
    /// <summary>
    /// The operation was successful.
    /// </summary>
    Success,

    /// <summary>
    /// The operation encountered an error.
    /// </summary>
    Error,

    /// <summary>
    /// The operation completed with warnings.
    /// </summary>
    Warning,

    /// <summary>
    /// The operation returned informational messages.
    /// </summary>
    Information
}

