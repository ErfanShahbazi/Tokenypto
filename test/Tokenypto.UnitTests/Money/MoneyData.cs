using Tokenypto.Api.Entities;

namespace Tokenypto.Api.UnitTests;

internal static class MoneyData
{
    internal static Money ZeroEuro = new Money(0, Currency.Euro);

    internal static Money USD_50 = new Money(50, Currency.UnitedStatesDollar);
    internal static Money EUR_100 = new Money(100, Currency.Euro);
}
