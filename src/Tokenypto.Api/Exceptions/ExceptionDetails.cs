namespace Tokenypto.Api.Exceptions;

public record ExceptionDetails(
int StatusCode,
string Title,
string Detail);
