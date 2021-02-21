# Finnhub API Client

[![.NET CI](https://github.com/pviotti/finnhub-dotnet/workflows/.NET%20CI/badge.svg)](https://github.com/pviotti/finnhub-dotnet/actions?query=workflow%3A%22.NET+CI%22+branch%3Amain)

.NET client for [Finnhub API](https://finnhub.io/docs/api/).

:warning: **Caveat** :warning: : at the moment only free APIs are supported,
such as: <TODO insert list>
There isn't any technical reason preventing the implementation of the other API and 
I welcome contributions (please tag me in PRs or Issues as I might not get the notification.)

## Usage

```fsharp
open Finnhub
let client = FinnhubClient("your-api-key")
client.GetQuote "APPL" |> printfn
```

## Related project

There are a few other Finnhub API clients for .NET, including: 

 - [ThreeFourteen.FinnhubClient](https://github.com/KevWK314/ThreeFourteen.FinnhubClient)
 - [FinnHub.NET](https://github.com/ridicoulous/FinnHub.Net)
 
However, the existing clients had some issues (e.g. lack of API coverage, lack of documentation)
so I decided to write this client.
