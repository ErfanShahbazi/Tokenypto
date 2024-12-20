using Carter;
using Serilog;
using Tokenypto.Api.Configurations.ApiVersioningConfiguration;
using Tokenypto.Api.Configurations.CoinMarketCapConfiguration;
using Tokenypto.Api.Configurations.ExceptionHandlingConfiguration;
using Tokenypto.Api.Configurations.HttpClientConfiguration;
using Tokenypto.Api.Configurations.SerilogConfiguration;
using Tokenypto.Api.Configurations.ServicesConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

// Add and Use Serilog
builder.AddSerilogConfiguration();

// Add options
builder.AddCoinMarketCapConfiguration();

builder.Services.AddServicesConfiguration();
builder.Services.AddHttpClientConfiguration();
builder.Services.AddCarter();

builder.Services.AddApiVersioningConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();


var app = builder.Build();


if (app.Environment.IsDevelopment() || true)
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var groupName in descriptions.Select(description => description.GroupName))
        {
            var url = $"/swagger/{groupName}/swagger.json";
            var name = groupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}


app.UseHttpsRedirection();

// Serilog request logging
app.UseSerilogRequestLogging();

// Custom exception handler middleware
app.UseCustomExceptionHandler();

// Api Versioning
app.UseApiVersioning();

// For Registering ICarterModule s
app.MapCarter();

app.Run();


public partial class Program;