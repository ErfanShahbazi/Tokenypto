using FluentResults;
using System.Net;

namespace Tokenypto.Api.Exceptions
{
    public class CustomException : Exception
    {
        public readonly Error Error;
        public readonly HttpStatusCode StatusCode;

        public CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Error = new Error(message);
            StatusCode = statusCode;
        }
    }
}
