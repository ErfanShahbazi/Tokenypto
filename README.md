# Tokenypto

![Test Passed](https://img.shields.io/badge/Tests-Passed-brightgreen)

This project is a .Net Core Web API project that provides endpoints for retrieving cryptocurrency information. The APIs allow users to fetch exchange rates and other details about crypto currencies.

## Current Features
- Retrieve the exchange rate of a cryptocurrency based on a currency.
- Get Cryptocurrency Price in 5 currencies (`USD`,`EUR`,`BRL`,`AUD`,`GBP`)


### 1. Get Exchange Rate
Retrieve the exchange rate of a cryptocurrency based on a currency.

**Request**:
```
GET /api/v1/crypto/exchange
```

**Query Parameters**:
- `cryptoCurrencySign` (string, required): The symbol of the cryptocurrency (e.g., `btc`).
- `currencySign` (string, required): The symbol of the fiat currency (e.g., `usd`).

**Example**:
```
GET {{Tokenypto.Api_HostAddress}}/api/v1/crypto/exchange?cryptoCurrencySign=btc&currencySign=usd
```

**Response**:
```json
{
  "value": {
    "cryptoCurrency": {
      "sign": "BTC"
    },
    "priceData": {
      "amount": 97020.27337310933,
      "currency": {
        "sign": "USD"
      }
    }
  },
  "isSuccess": true,
  "isFailure": false,
  "error": {
    "code": "",
    "description": ""
  }
}
```

### 2. Get Cryptocurrency Price in 5 currencies (`USD`,`EUR`,`BRL`,`AUD`,`GBP`)
Retrieve details about a specific cryptocurrency based on 5 currencies (USD,EUR,BRL,AUD,GBP).

**Request**:
```
GET /api/v1/crypto
```

**Query Parameters**:
- `cryptoCurrencySign` (string, required): The symbol of the cryptocurrency (e.g., `BTC`).


**Example**:
```
GET {{Tokenypto.Api_HostAddress}}/api/v1/crypto?cryptoCurrencySign=BTC
```

**Response**:
```json
{
  "value": [
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
        "amount": 97087.45531054199,
        "currency": {
          "sign": "USD"
        }
      }
    },
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
        "amount": 155290.21971974734,
        "currency": {
          "sign": "AUD"
        }
      }
    },
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
        "amount": 93071.43272162169,
        "currency": {
          "sign": "EUR"
        }
      }
    },
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
        "amount": 590874.2530199722,
        "currency": {
          "sign": "BRL"
        }
      }
    },
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
        "amount": 77231.32312534082,
        "currency": {
          "sign": "GBP"
        }
      }
    }
  ],
  "isSuccess": true,
  "isFailure": false,
  "error": {
    "code": "",
    "description": ""
  }
}
```



## Notice
Because of limited access to CoinMarketCap APIs, I had to call multiple apis for a single response and this is not the ideal approach.


