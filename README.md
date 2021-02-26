# Finnhub API .NET Client

[![.NET CI](https://github.com/pviotti/finnhub-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pviotti/finnhub-dotnet/actions/workflows/dotnet.yml)

A .NET client for [Finnhub API][finnhub-api].

At the moment only some APIs are supported (mainly the free ones [TODO: insert list]).
There isn't any technical reason preventing the implementation of the other API and 
I welcome contributions.

## Install

```
dotnet add package FinnhubDotNet
```

## Usage

```fsharp
open Finnhub
let client = FinnhubClient "your-api-key"
client.GetQuote "APPL" |> printfn "%A"
```

## Related projects

There are a few other Finnhub API clients for .NET, such as 
[ThreeFourteen.FinnhubClient][finnhub-threefourteen] and 
[FinnHub.NET][finnhub-.net].
However, the existing clients had some issues (e.g. lack of API coverage, lack of documentation).
I also prefer to have a simpler and more concise API wrapper without any external dependencies,
so I decided to write this client.

 [finnhub-api]: https://finnhub.io/docs/api/
 [finnhub-threefourteen]: https://github.com/KevWK314/ThreeFourteen.FinnhubClient
 [finnhub-.net]: https://github.com/ridicoulous/FinnHub.Net
