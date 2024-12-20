using FluentResults;
using Tokenypto.Api.Services.Crypto.DTOs;

namespace Tokenypto.Api.Services.Crypto;

public interface ICryptoService
{
    Task<Result<List<GetCryptoCurrencyQuoteResultDTO>>> GetPricesForCryptoCurrencyAsync(string cryptoCurrencySign, CancellationToken cancellationToken);
    Task<Result<GetCryptoCurrencyQuoteResultDTO>> GetPriceOfCryptoCurrencyAsync(string cryptoCurrencySign, string currencySign, CancellationToken cancellationToken);
}
