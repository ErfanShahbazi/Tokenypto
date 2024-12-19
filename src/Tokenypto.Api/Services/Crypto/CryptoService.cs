using FluentResults;
using Microsoft.Extensions.Options;
using System.Net;
using Tokenypto.Api.Configurations.CoinMarketCapConfiguration;
using Tokenypto.Api.Entities;
using Tokenypto.Api.Exceptions;
using Tokenypto.Api.Services.Crypto.DTOs;
using Tokenypto.Api.Services.Crypto.Models;
namespace Tokenypto.Api.Services.Crypto
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _client;
        private readonly IOptions<CoinMarketCapOptions> _coinMarketCapOptions;

        public CryptoService(IOptions<CoinMarketCapOptions> coinMarketCapOptions, HttpClient client)
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

            Result<List<GetCryptoCurrencyQuoteResultDTO>> result = new Result<List<GetCryptoCurrencyQuoteResultDTO>>().WithValue(listOfQuotes);

            return result;
        }

        public async Task<Result<GetCryptoCurrencyQuoteResultDTO>> GetPriceOfCryptoCurrencyAsync(string cryptoCurrencySign, string currencySign, CancellationToken cancellationToken)
        {
            cryptoCurrencySign = cryptoCurrencySign.ToUpper();
            currencySign = currencySign.ToUpper();

            Currency currency = Currency.FromCode(currencySign);
            CryptoCurrency cryptoCurrency = new(cryptoCurrencySign);


            string endpoint = _coinMarketCapOptions.Value.BaseURL + "quotes/latest";
            string query = $"symbol={cryptoCurrencySign}&convert={currencySign}";

            var httpResponseMessage = await _client.GetAsync($"{endpoint}?{query}", cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();

            CoinMarketCapResponse responseData = await httpResponseMessage.Content.ReadFromJsonAsync<CoinMarketCapResponse>(cancellationToken) ?? throw new CustomException($"No response from API: {endpoint}?{query}");


            Money price = new(responseData.Data[cryptoCurrencySign]?.Quote[currencySign]?.Price ?? throw new CustomException("No Data found!", HttpStatusCode.NotFound), currency);
            GetCryptoCurrencyQuoteResultDTO data = new(cryptoCurrency, price);


            var result = new Result<GetCryptoCurrencyQuoteResultDTO>().WithValue(data);
            return result;
        }
    }
}
