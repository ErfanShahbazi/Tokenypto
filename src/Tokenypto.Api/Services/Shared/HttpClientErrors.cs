using Tokenypto.Api.Entities.Abstractions;

namespace Tokenypto.Api.Services.Shared;

public static class HttpClientErrors
{
    public static readonly Error NoResponse = new Error("HttpClientError.NoResponse", "No response from endpoint!");
}
