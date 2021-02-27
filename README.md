# Finnhub API .NET Client

[![.NET CI](https://github.com/pviotti/finnhub-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pviotti/finnhub-dotnet/actions/workflows/dotnet.yml)
[![NuGet version (Finnhub)](https://img.shields.io/nuget/v/Finnhub.svg?style=flat&color=blue)][nuget]

A .NET client for [Finnhub API][finnhub-api]. 
It's written in F# and only supports .NET 5+ since it uses [System.Text.JSON](system.text.json) 
and the [JSON HTTP extension][system.net.http.json] from its standard library.

:construction_worker: *At the moment only some APIs are supported 
(mainly the non-Premium ones, see [here][missing-apis]).
There isn't any technical reason preventing the implementation of the other APIs, and 
I welcome contributions.*

## Install

```
dotnet add package Finnhub
```
See [nuget.org][nuget].

## Usage

```fsharp
open Finnhub
let client = Client "your-api-key"
client.Quote "AAPL"
	|> Async.RunSynchronously
    |> printfn "%A"
```
*[TODO: add C# example]*

## Related projects

There are a few other Finnhub API clients for .NET, such as 
[ThreeFourteen.FinnhubClient][finnhub-threefourteen] and 
[FinnHub.NET][finnhub-.net].
However, the existing clients have some issues (e.g. lack of API coverage, lack of documentation).
Also, I'd rather have a simpler API wrapper without any external dependencies,
so I decided to write this.

 [finnhub-api]: https://finnhub.io/docs/api/
 [finnhub-threefourteen]: https://github.com/KevWK314/ThreeFourteen.FinnhubClient
 [finnhub-.net]: https://github.com/ridicoulous/FinnHub.Net
 [system.text.json]: https://docs.microsoft.com/en-us/dotnet/api/system.text.json
 [system.net.http.json]: https://docs.microsoft.com/en-us/dotnet/api/system.net.http.json
 [missing-apis]: https://github.com/pviotti/finnhub-dotnet/issues/2
 [nuget]: https://www.nuget.org/packages/Finnhub/