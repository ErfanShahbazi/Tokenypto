using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tokenypto.Api.Configurations.CoinMarketCapConfiguration;
using Tokenypto.Api.Services.Crypto;

namespace Tokenypto.Api.UnitTests
{
    public class GetCryptoCurrencyTests
    {
        private readonly ICryptoService _cryptoServiceMock;

        private readonly HttpClient _clientMock;
        private readonly IOptions<CoinMarketCapOptions> _coinMarketCapOptionsMock;

        public GetCryptoCurrencyTests()
        {
            _clientMock = Substitute.For<HttpClient>();
            _coinMarketCapOptionsMock = Options.Create<CoinMarketCapOptions>(new CoinMarketCapOptions() { APIKey = "6fd5fa9d-5117-4a81-8251-01d2b7f97bcb", BaseURL = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/" });

            _cryptoServiceMock = new CryptoService(_coinMarketCapOptionsMock, _clientMock);
        }


        [Fact]
        public async void GetPriceOfADAUSD_Should_ReturnNonZeroValue()
        {
            // Arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(3000);
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Act
            var result = await _cryptoServiceMock.GetPriceOfCryptoCurrencyAsync("ADA", "USD", cancellationToken);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Money.Amount.Should().BeGreaterThan(0);
        }

        [Fact]
        public async void GetPriceOfWrongCoin_Should_ThrowException()
        {
            // Arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(3000);
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Act and Assert
            await Assert.ThrowsAsync<JsonException>(async () => await _cryptoServiceMock.GetPriceOfCryptoCurrencyAsync("Wrong", "USD", cancellationToken));
        }

        [InlineData("ADA")]
        [InlineData("BTC")]
        [InlineData("XRP")]
        [Theory]
        public async Task GetPricesFor_Should_SuccessfullyReturnFiveQuotes(string sign)
        {
            // Arrange
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(3000);
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Act
            var result = await _cryptoServiceMock.GetPricesForCryptoCurrencyAsync(sign, cancellationToken);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Count.Should().Be(5);
        }
    }
}
