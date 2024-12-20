using Microsoft.Extensions.Options;
using System.Net;
using Tokenypto.Api.Configurations.CoinMarketCapConfiguration;
using Tokenypto.Api.Entities;
using Tokenypto.Api.Entities.Abstractions;
using Tokenypto.Api.Exceptions;
using Tokenypto.Api.Services.Crypto.DTOs;
using Tokenypto.Api.Services.Crypto.Models;
using Tokenypto.Api.Services.Shared;

namespace Tokenypto.Api.Services.Crypto;

public class CoinMarketCapService : ICryptoService
{
    private readonly HttpClient _client;
    private readonly IOptions<CoinMarketCapOptions> _coinMarketCapOptions;

    public CoinMarketCapService(IOptions<CoinMarketCapOptions> coinMarketCapOptions, HttpClient client)
    {
        _coinMarketCapOptions = coinMarketCapOptions;
        _client = client;
        _client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _coinMarketCapOptions.Value.APIKey);
        _client.DefaultRequestHeaders.Add("Accepts", "application/json");
    }

    public async Task<Result<List<GetCryptoCurrencyQuoteResultDTO>>> GetPricesForCryptoCurrencyAsync(string cryptoCurrencySign, CancellationToken cancellationToken)
    {
        List<GetCryptoCurrencyQuoteResultDTO> listOfQuotes = new();

        foreach (var item in Currency.All)
        {
            Result<GetCryptoCurrencyQuoteResultDTO> signResult = await GetPriceOfCryptoCurrencyAsync(cryptoCurrencySign, item.Sign, cancellationToken);
            listOfQuotes.Add(signResult.Value);
        }

        Result<List<GetCryptoCurrencyQuoteResultDTO>> result = Result.Success(listOfQuotes);

        return result;
    }

    public async Task<Result<GetCryptoCurrencyQuoteResultDTO>> GetPriceOfCryptoCurrencyAsync(string cryptoCurrencySign, string currencySign, CancellationToken cancellationToken)
    {

        cryptoCurrencySign = cryptoCurrencySign.ToUpper();
        currencySign = currencySign.ToUpper();

        Currency currency = Currency.FromCode(currencySign);
        CryptoCurrency cryptoCurrency = new(cryptoCurrencySign);


        string endpoint = _coinMarketCapOptions.Value.BaseURL + "/v1/cryptocurrency/quotes/latest";
        string query = $"symbol={cryptoCurrencySign}&convert={currencySign}";

        var httpResponseMessage = await _client.GetAsync($"{endpoint}?{query}", cancellationToken);
        httpResponseMessage.EnsureSuccessStatusCode();

        CoinMarketCapResponse responseData = await httpResponseMessage.Content.ReadFromJsonAsync<CoinMarketCapResponse>(cancellationToken) ?? throw new CustomException(HttpClientErrors.NoResponse, HttpStatusCode.NotFound);


        var priceAmount = responseData.GetPrice(cryptoCurrencySign, currencySign);
        var price = new Money(priceAmount, currency);
        GetCryptoCurrencyQuoteResultDTO data = new(cryptoCurrency, price);


        var result = Result.Success(data);
        return result;
    }
}
