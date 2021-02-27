module FinnHub.Test

open NUnit.Framework
open FsUnit
open System
open System.Net
open System.Net.Http

open Finnhub

let key =
    Environment.GetEnvironmentVariable "finnhubkey"

let client = Client key

[<Test>]
let TestAll () =
    client.CompanyProfile "AAPL"
    |> Async.RunSynchronously
    |> should be instanceOfType<CompanyProfile>

    client.SymbolLookup "apple"
    |> Async.RunSynchronously
    |> should be instanceOfType<SymbolLookup>

    client.CompanyNews "AAPL" "2020-04-30" "2020-05-01"
    |> Async.RunSynchronously
    |> should be instanceOfType<CompanyNews>

    client.NewsSentiment "V"
    |> Async.RunSynchronously
    |> should be instanceOfType<NewsSentiment>

    client.BasicFinancials "AAPL"
    |> Async.RunSynchronously
    |> should be instanceOfType<BasicFinancials>

    client.IPOCalendar "2020-03-15" "2020-03-16"
    |> Async.RunSynchronously
    |> should be instanceOfType<IPOCalendar>

    client.Recommendation "AAPL"
    |> Async.RunSynchronously
    |> should be instanceOfType<Recommendation>

    client.EarningCalendar "2020-03-15" "2020-03-16"
    |> Async.RunSynchronously
    |> should be instanceOfType<EarningCalendar>

    client.Quote "AAPL"
    |> Async.RunSynchronously
    |> should be instanceOfType<Quote>


[<Test>]
let TestExceptions () =
    let faultyClient = Client "WRONG"

    // wrong key -> HttpRequestException, HTTP 401
    try
        faultyClient.Quote "AAPL"
        |> Async.RunSynchronously
        |> ignore

        Assert.Fail "Should have thrown an exception before."
    with :? System.AggregateException as ex ->
        Assert.AreEqual(typeof<HttpRequestException>, ex.InnerException.GetType())

        let iex =
            ex.InnerException :?> HttpRequestException

        Assert.AreEqual(HttpStatusCode.Unauthorized, iex.StatusCode.Value)

    // wrong URL -> redirect to HTML page, JsonException
    faultyClient.HttpClient <- new HttpClient(BaseAddress = Uri("https://finnhub.io/api/WRONG/"))
    try
        faultyClient.Quote "AAPL"
        |> Async.RunSynchronously
        |> ignore

        Assert.Fail "Should have thrown an exception before."
    with :? System.AggregateException as ex ->
        Assert.AreEqual(typeof<System.Text.Json.JsonException>, ex.InnerException.GetType())



[<EntryPoint>]
let main _ = 0
