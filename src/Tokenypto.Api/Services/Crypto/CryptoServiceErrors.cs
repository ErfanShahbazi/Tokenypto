using Tokenypto.Api.Entities.Abstractions;

namespace Tokenypto.Api.Services.Crypto;

public static class CryptoServiceErrors
{
    public static readonly Error NoPriceDataFound = new Error("CryptoError.NoPriceDataFound", "No price data for this crypto currency found !");
    public static readonly Error NoData = new Error("CryptoError.NoData", "Could not gatter any data!");
}
