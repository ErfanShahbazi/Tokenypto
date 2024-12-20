using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Tokenypto.Api.Services.Crypto;

namespace Tokenypto.Api.Configurations.HttpClientConfiguration;

public static class HttpClientConfiguration
{
    public static IServiceCollection AddHttpClientConfiguration(
    this IServiceCollection services)
    {
        services.AddHttpClient<ICryptoService, CoinMarketCapService>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
        })
        .SetHandlerLifetime(TimeSpan.FromMinutes(5))
        .AddPolicyHandler(GetRetryPolicy());

        return services;
    }

    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(2));
    }
}
