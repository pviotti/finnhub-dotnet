module FinnHub.Test

open NUnit.Framework
open FsUnit
open System

open Finnhub

[<SetUp>]
let Setup () = ()

[<Test>]
let TestAll () =
    let key =
        Environment.GetEnvironmentVariable "finnhubkey"

    let client = Client key

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

    client.Quote "APPL"
    |> Async.RunSynchronously
    |> should be instanceOfType<Quote>



[<EntryPoint>]
let main _ = 0
