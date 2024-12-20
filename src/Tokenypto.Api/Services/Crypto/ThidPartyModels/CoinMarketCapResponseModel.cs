using System.Net;
using Tokenypto.Api.Entities;
using Tokenypto.Api.Exceptions;

namespace Tokenypto.Api.Services.Crypto.Models
{

    public class CoinMarketCapResponse
    {
        public Dictionary<string, CoinMarketCapCryptoData> Data { get; set; } = new();


        public decimal GetPrice(string cryptoCurrencySign , string currencySign)
        {
            try
            {
                var price = Data[cryptoCurrencySign]?.Quote[currencySign]?.Price ?? throw new CustomException(CryptoServiceErrors.NoPriceDataFound, HttpStatusCode.NotFound);

                return price;
            }
            catch (KeyNotFoundException ex)
            {
                throw new CustomException(CryptoServiceErrors.NoPriceDataFound, HttpStatusCode.NotFound);
            }
        }

    }


    public class CoinMarketCapCryptoData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public Dictionary<string,CoinMarketCapQuote> Quote { get; set; } = new();
    }

    public class CoinMarketCapQuote
    {
        public decimal Price { get; set; }
    }
}
