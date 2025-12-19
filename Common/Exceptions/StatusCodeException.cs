namespace Common.Exceptions;

/// <summary>
/// Represents an exception that includes an HTTP status code, a title, and a detailed error message.
/// </summary>
/// <param name="statusCode">The HTTP status code that describes the error condition.</param>
/// <param name="title">A short, human-readable summary of the error.</param>
/// <param name="detail">A detailed message that provides additional information about the error.</param>
public class StatusCodeException(int statusCode, string title, string detail) 
    : Exception(detail)
{
    /// <summary>
    /// The HTTP status code associated with the exception.
    /// </summary>
    public int StatusCode { get; } = statusCode;

    /// <summary>
    /// The title of the error.
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// The detailed message of the error.
    /// </summary>
    public string Detail { get; } = detail;
}
