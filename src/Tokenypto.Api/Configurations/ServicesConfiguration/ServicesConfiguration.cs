using Tokenypto.Api.Services.Crypto;

namespace Tokenypto.Api.Configurations.ServicesConfiguration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(
        this IServiceCollection services)
        {
            services.AddScoped<ICryptoService, CryptoService>();
            return services;
        }

    }
}
