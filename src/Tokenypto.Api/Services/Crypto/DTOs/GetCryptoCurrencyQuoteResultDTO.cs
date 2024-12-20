using Tokenypto.Api.Entities;

namespace Tokenypto.Api.Services.Crypto.DTOs
{
    public record GetCryptoCurrencyQuoteResultDTO(CryptoCurrency CryptoCurrency, Money Money);
}
