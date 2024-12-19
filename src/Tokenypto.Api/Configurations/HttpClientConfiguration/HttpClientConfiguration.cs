using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using Tokenypto.Api.Services.Crypto;

namespace Tokenypto.Api.Configurations.HttpClientConfiguration
{
    public static class HttpClientConfiguration
    {
        public static IServiceCollection AddHttpClientConfiguration(
        this IServiceCollection services)
        {
            services.AddHttpClient<ICryptoService>()
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                    .AddPolicyHandler(GetRetryPolicy());

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                   .HandleTransientHttpError()
                   .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(1));
        }
    }
}
