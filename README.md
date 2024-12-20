# Tokenypto

![Test Passing](https://img.shields.io/badge/Tests-Passed-brightgreen)

This project is a .Net Core Web API project that provide endpoints for retrieving cryptocurrency information. The APIs allow users to fetch exchange rates and other details about crypto currencies.

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
  "valueOrDefault": {
    "cryptoCurrency": {
      "sign": "BTC"
    },
    "priceData": {
      "amount": 97051.29232863031,
      "currency": {
        "sign": "USD"
      }
    }
  },
  "value": {
    "cryptoCurrency": {
      "sign": "BTC"
    },
    "priceData": {
      "amount": 97051.29232863031,
      "currency": {
        "sign": "USD"
      }
    }
  },
  "isFailed": false,
  "isSuccess": true,
  "reasons": [],
  "errors": [],
  "successes": []
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
  "valueOrDefault": [
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
    "amount": 97059.0582093153,
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
        "amount": 154952.35995471667,
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
        "amount": 92978.88952031243,
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
        "amount": 588595.2466987657,
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
        "amount": 77079.06284069488,
        "currency": {
            "sign": "GBP"
        }
    }
}
  ],
  "value": [
    {
      "cryptoCurrency": {
        "sign": "BTC"
      },
      "priceData": {
    "amount": 97059.0582093153,
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
        "amount": 154952.35995471667,
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
        "amount": 92978.88952031243,
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
        "amount": 588595.2466987657,
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
        "amount": 77079.06284069488,
        "currency": {
            "sign": "GBP"
        }
    }
}
  ],
  "isFailed": false,
  "isSuccess": true,
  "reasons": [],
  "errors": [],
  "successes": []
}
```



## Notice
Because of limited access to CoinMarketCap APIs, I had to call multiple apis for a single response and this is not the ideal approach.


