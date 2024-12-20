using Asp.Versioning;
using Asp.Versioning.Builder;

namespace Tokenypto.Api.Configurations.ApiVersioningConfiguration;

public static class ApiVersioningConfiguration
{
    public static ApiVersionSet ApiVersionSet;

    public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static void UseApiVersioning(this WebApplication app)
    {
        ApiVersionSet = app.NewApiVersionSet()
        .HasApiVersion(new ApiVersion(1))
        .HasApiVersion(new ApiVersion(2))
        .ReportApiVersions()
        .Build();
    }
}
