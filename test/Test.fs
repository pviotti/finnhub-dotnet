module FinnHub.Test

open NUnit.Framework
open FsUnit
open System
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
    let newClient = Client key
    newClient.HttpClient <- new HttpClient(BaseAddress = Uri("https://finnhub.io/api/WRONG/"))

    (fun () ->
        newClient.Quote "AAPL"
        |> Async.RunSynchronously
        |> ignore)
    |> should throw typeof<System.AggregateException>


[<EntryPoint>]
let main _ = 0
