using Tokenypto.Api.Middlewares;

namespace Tokenypto.Api.Configurations.ExceptionHandlingConfiguration;

public static class ExceptionHandlingConfiguration
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    => app.UseMiddleware<ExceptionHandlingMiddleware>();
}
