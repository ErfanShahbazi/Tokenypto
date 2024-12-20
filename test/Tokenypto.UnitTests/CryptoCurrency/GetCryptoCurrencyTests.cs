﻿using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using System.Text.Json;
using Tokenypto.Api.Configurations.CoinMarketCapConfiguration;
using Tokenypto.Api.Services.Crypto;

namespace Tokenypto.Api.UnitTests;

public class GetCryptoCurrencyTests
{
    private readonly ICryptoService _cryptoServiceMock;

    private readonly HttpClient _clientMock;
    private readonly IOptions<CoinMarketCapOptions> _coinMarketCapOptionsMock;

    public GetCryptoCurrencyTests()
    {
        _clientMock = Substitute.For<HttpClient>();
        _coinMarketCapOptionsMock = Options.Create<CoinMarketCapOptions>(new CoinMarketCapOptions() { APIKey = "6fd5fa9d-5117-4a81-8251-01d2b7f97bcb", BaseURL = "https://pro-api.coinmarketcap.com" });

        _cryptoServiceMock = new CoinMarketCapService(_coinMarketCapOptionsMock, _clientMock);
    }



    [InlineData(["ADA", "USD"])]
    [InlineData(["BTC", "EUR"])]
    [InlineData(["XRP", "AUD"])]
    [Theory]
    public async Task GetPrice_Should_ReturnNonZeroValue(string cryptoCurrencySign, string currencySign)
    {
        // Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(3000);
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        // Act
        var result = await _cryptoServiceMock.GetPriceOfCryptoCurrencyAsync(cryptoCurrencySign, currencySign, cancellationToken);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.PriceData.Amount.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetPriceOfWrongCoin_Should_ThrowException()
    {
        // Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(10000);
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        // Act and Assert
        await Assert.ThrowsAsync<JsonException>(async () => await _cryptoServiceMock.GetPriceOfCryptoCurrencyAsync("Wrong", "USD", cancellationToken));
    }

    [InlineData("ADA")]
    [InlineData("BTC")]
    [InlineData("XRP")]
    [Theory]
    public async Task GetPricesFor_Should_SuccessfullyReturnFiveQuotes(string cryptoCurrencySign)
    {
        // Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(10000);
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        // Act
        var result = await _cryptoServiceMock.GetPricesForCryptoCurrencyAsync(cryptoCurrencySign, cancellationToken);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Count.Should().Be(5);
        foreach (var item in result.Value)
        {
            item.PriceData.Amount.Should().BeGreaterThan(0);
        }
    }
}
