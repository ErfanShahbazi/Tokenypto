using System.Net;
using Tokenypto.Api.Entities.Abstractions;

namespace Tokenypto.Api.Exceptions;

public class CustomException : Exception
{
    public readonly Error Error;
    public readonly HttpStatusCode StatusCode;

    public CustomException(string title, string message = "", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            message = title;
        }
        Error = new Error(title, message);
        StatusCode = statusCode;
    }

    public CustomException(Error error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        Error = error;
        StatusCode = statusCode;
    }
}
