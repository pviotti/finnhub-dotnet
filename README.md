# Finnhub API Client

[![.NET CI](https://github.com/pviotti/finnhub-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pviotti/finnhub-dotnet/actions/workflows/dotnet.yml)

.NET client for [Finnhub API][finnhub-api].

:warning: **Caveat** :warning: : at the moment only some APIs are supported (mainly the free ones),
such as: <TODO insert list>
There isn't any technical reason preventing the implementation of the other API and 
I welcome contributions (please tag me in PRs or Issues as I might not get the notification.)

## Install

```
dotnet add package FinnhubDotNet
```

## Usage

```fsharp
open Finnhub
let client = FinnhubClient("your-api-key")
client.GetQuote "APPL" |> printfn "%A"
```

## Related projects

There are a few other Finnhub API clients for .NET, including: 

 - [ThreeFourteen.FinnhubClient][finnhub-threefourteen]
 - [FinnHub.NET][finnhub-.net]
 
However, the existing clients had some issues (e.g. lack of API coverage, lack of documentation),
and more generally I wanted to have a API wrapper as simple and terse as [its Python implementation][finnhub-py],
so I decided to write this client.

 [finnhub-py]: https://github.com/Finnhub-Stock-API/finnhub-python/blob/master/finnhub/client.py
 [finnhub-api]: https://finnhub.io/docs/api/
 [finnhub-threefourteen]: https://github.com/KevWK314/ThreeFourteen.FinnhubClient
 [finnhub-.net]: https://github.com/ridicoulous/FinnHub.Net
