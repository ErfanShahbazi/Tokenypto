﻿using Tokenypto.Api.Entities.Abstractions;
using Tokenypto.Api.Exceptions;

namespace Tokenypto.Api.Middlewares;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            ExceptionDetails exceptionDetails = GetExceptionDetails(exception);

            Result failureResult = Result.Failure(new Error(exceptionDetails.Title, exceptionDetails.Detail));

            context.Response.StatusCode = exceptionDetails.StatusCode;
            await context.Response.WriteAsJsonAsync(failureResult);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            CustomException customException => new ExceptionDetails(
                (int)customException.StatusCode,
                customException.Error.Code,
                customException.Error.Description
                ),
            ApplicationException applicationException => new ExceptionDetails(
                (int)StatusCodes.Status400BadRequest,
                "Invalid Data",
                "Invalid Data !"
                ),
            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "Server Error",
                "An unexpected error has occurred")
        };
    }

}
