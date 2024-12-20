using Carter;
using Tokenypto.Api.Configurations.ApiVersioningConfiguration;
using Tokenypto.Api.Entities.Abstractions;
using Tokenypto.Api.Services.Crypto;
using Tokenypto.Api.Services.Crypto.DTOs;

namespace Tokenypto.Api.Modules;

public class CryptoModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v{version:apiVersion}/crypto", async (ICryptoService cryptoService, CancellationToken cancellationToken, string cryptoCurrencySign) =>
        {
            Result<List<GetCryptoCurrencyQuoteResultDTO>> result = await cryptoService.GetPricesForCryptoCurrencyAsync(cryptoCurrencySign, cancellationToken);
            return result;
        })
        .WithApiVersionSet(ApiVersioningConfiguration.ApiVersionSet)
        .MapToApiVersion(1);


        app.MapGet("api/v{version:apiVersion}/crypto/exchange", async (ICryptoService cryptoService, CancellationToken cancellationToken, string cryptoCurrencySign, string currencySign) =>
        {
            Result<GetCryptoCurrencyQuoteResultDTO> result = await cryptoService.GetPriceOfCryptoCurrencyAsync(cryptoCurrencySign, currencySign, cancellationToken);
            return result;
        })
        .WithApiVersionSet(ApiVersioningConfiguration.ApiVersionSet)
        .MapToApiVersion(1);
    }
}
