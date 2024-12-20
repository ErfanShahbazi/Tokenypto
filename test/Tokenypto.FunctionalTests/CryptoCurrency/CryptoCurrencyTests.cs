using FluentAssertions;
using Tokenypto.FunctionalTests.Infrastructure;

namespace Tokenypto.FunctionalTests.CryptoCurrency;

public class CryptoCurrencyTests : BaseFunctionalTest
{
    public CryptoCurrencyTests(FunctionalTestWebAppFactory webAppFactory) : base(webAppFactory)
    {
    }


    [Fact]
    public async Task GetPrice_Should_ReturnOKWhenInputIsValid()
    {
        // Arrange
        var cryptoCurrencySign = "ADA";

        // Act
        var response = await Client.GetAsync($"/api/v1/crypto?cryptoCurrencySign={cryptoCurrencySign}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetPrices_Should_ReturnOkWhenInputIsValid()
    {
        // Arrange
        var cryptoCurrencySign = "ADA";
        var currencySign = "USD";

        // Act
        var response = await Client.GetAsync($"/api/v1/crypto/exchange?cryptoCurrencySign={cryptoCurrencySign}&currencySign={currencySign}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetPrice_Should_Return404WhenInputIsInValid()
    {
        // Arrange
        var cryptoCurrencySign = "ADAP";

        // Act
        var response = await Client.GetAsync($"/api/v1/crypto?cryptoCurrencySign={cryptoCurrencySign}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetPrices_Should_Return404WhenInputIsInvalid()
    {
        // Arrange
        var cryptoCurrencySign = "ADAS";
        var currencySign = "USD";

        // Act
        var response = await Client.GetAsync($"/api/v1/crypto/exchange?cryptoCurrencySign={cryptoCurrencySign}&currencySign={currencySign}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }
}
