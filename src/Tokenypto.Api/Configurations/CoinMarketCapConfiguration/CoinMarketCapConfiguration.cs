namespace Tokenypto.Api.Configurations.CoinMarketCapConfiguration
{
    public static class CoinMarketCapConfiguration
    {
        public static WebApplicationBuilder AddCoinMarketCapConfiguration(
        this WebApplicationBuilder builder)
        {
            builder.Services.Configure<CoinMarketCapOptions>(
                            builder.Configuration.GetSection(nameof(CoinMarketCapOptions)));
            return builder;
        }
    }

    public class CoinMarketCapOptions
    {
        public string APIKey { get; set; } = String.Empty;
        public string BaseURL { get; set; } = String.Empty;
    }
}
