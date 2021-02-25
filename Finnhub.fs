//namespace FinnhubDotNet

module FinnhubDotNet

open System
open System.Net.Http
open System.Net.Http.Json

open Model

type Client(key: string) =
    let key = key

    let httpClient =
        new HttpClient(BaseAddress = Uri("https://finnhub.io/api/v1/"))

    let joinParameters (parameters: list<string * string>) =
        parameters
        |> List.append [ ("token", key) ]
        |> List.map (fun x -> fst (x) + "=" + snd (x))
        |> String.concat "&"

    member _._request<'T> path (parameters: list<string * string>) =
        async {
            let uri = path + joinParameters (parameters)

            return!
                httpClient.GetFromJsonAsync<'T> uri
                |> Async.AwaitTask
        }

    member this.CompanyProfile symbol =
        this._request<CompanyProfile> "stock/profile2?" [ ("symbol", symbol) ]

    member this.SymbolLookup query =
        this._request<SymbolLookup> "search?" [ ("q", query) ]

    member this.CompanyNews symbol fromDate toDate =
        this._request<News>
            "company-news?"
            [ ("symbol", symbol)
              ("from", fromDate)
              ("to", toDate) ]

    member this.NewsSentiment symbol =
        this._request<NewsSentiment> "news-sentiment?" [ ("symbol", symbol) ]

[<EntryPoint>]
let main _argv =
    let key = Environment.GetEnvironmentVariable "finnhubkey"
    let client = Client key

    let companyProfile =
        client.CompanyProfile "AAPL"
        |> Async.RunSynchronously

    printfn "%s" companyProfile.exchange
    printfn "%A" companyProfile

    let res =
        client.SymbolLookup "apple"
        |> Async.RunSynchronously
    printfn "%A" res

    let resSentiment =
        client.CompanyNews "AAPL" "2020-04-30" "2020-05-01"
        |> Async.RunSynchronously
    printfn "%A" res

    let resSentiment = client.NewsSentiment "V" |> Async.RunSynchronously
    printfn "%A" resSentiment
    0
