using Serilog;

namespace Tokenypto.Api.Configurations.SerilogConfiguration;

public static class SerilogConfiguration
{
    public static void AddSerilogConfiguration(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
                                configuration.ReadFrom.Configuration(context.Configuration));
    }
}
