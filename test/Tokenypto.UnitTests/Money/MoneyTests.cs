using FluentAssertions;

namespace Tokenypto.Api.UnitTests;

public class MoneyTests
{
    [Fact]
    public void IsZero_ForZeroMoney_Should_ReturnTrue()
    {
        // Arrange
        var zeroMoney = MoneyData.ZeroEuro;
        // Assert
        zeroMoney.IsZero().Should().BeTrue();
    }

    [Fact]
    public void MinusOperation_ForDifferenctCurrencies_Should_ThrowInvalidOperationException()
    {
        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => MoneyData.USD_50 - MoneyData.EUR_100);
    }

    [Fact]
    public void PlusOperation_ForDifferenctCurrencies_Should_ThrowInvalidOperationException()
    {
        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => MoneyData.USD_50 + MoneyData.EUR_100);
    }
}
