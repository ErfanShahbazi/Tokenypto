using Tokenypto.Api.FunctionalTests.Infrastructure;
using Tokenypto.Api.Services.Crypto.DTOs;
using FluentAssertions;
using System.Net.Http.Json;
using FluentResults;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Tokenypto.Api.Services.Crypto;
using Tokenypto.Api.Configurations.CoinMarketCapConfiguration;

namespace Tokenypto.Api.FunctionalTests.CryptoCurrency
{
    public class GetCryptoCurrencyTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public GetCryptoCurrencyTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Replace your services for testing
                    services.AddTransient<ICryptoService, CryptoService>();


                    // Configure IOptions
                    services.Configure<CoinMarketCapOptions>(options =>
                    {
                        services.Configure<CoinMarketCapOptions>(
                           );
                        return builder;
                    });
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetPriceOfADAUSD_Should_ReturnNonZeroValue()
        {
            try
            {

            // Arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(3000);
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            //Act
            HttpResponseMessage response = await HttpClient.GetAsync("api/v1/crypto?cryptoCurrencySign=ADA",cancellationToken);
            Result<GetCryptoCurrencyQuoteResultDTO> result = await response.Content.ReadFromJsonAsync<Result<GetCryptoCurrencyQuoteResultDTO>>(cancellationToken);

            //Assert
            result.Value.Money.Amount.Should().BeGreaterThan(0);
            }
            catch (Exception ex)
            {

                throw new Exception("Errrrsdasdasdasdasd");
            }
        }

    }
}
