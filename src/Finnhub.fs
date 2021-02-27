namespace Finnhub

open System
open System.Net.Http
open System.Net.Http.Json

type Client(key: string) =
    let key = key

    let joinParameters (parameters: list<string * string>) =
        parameters
        |> List.append [ ("token", key) ]
        |> List.map (fun x -> fst (x) + "=" + snd (x))
        |> String.concat "&"

    member val HttpClient = new HttpClient(BaseAddress = Uri("https://finnhub.io/api/v1/")) with get, set

    member this._request<'T> path (parameters: list<string * string>) =
        async {
            let uri = path + joinParameters (parameters)

            return!
                this.HttpClient.GetFromJsonAsync<'T> uri
                |> Async.AwaitTask
        }

    member this.CompanyProfile symbol =
        this._request<CompanyProfile> "stock/profile2?" [ ("symbol", symbol) ]

    member this.SymbolLookup query =
        this._request<SymbolLookup> "search?" [ ("q", query) ]

    member this.CompanyNews symbol fromDate toDate =
        this._request<CompanyNews>
            "company-news?"
            [ ("symbol", symbol)
              ("from", fromDate)
              ("to", toDate) ]

    member this.NewsSentiment symbol =
        this._request<NewsSentiment> "news-sentiment?" [ ("symbol", symbol) ]

    member this.BasicFinancials symbol =
        this._request<BasicFinancials>
            "stock/metric?"
            [ ("symbol", symbol)
              ("metric", "all") ]

    member this.IPOCalendar fromDate toDate =
        this._request<IPOCalendar> "calendar/ipo?" [ ("from", fromDate); ("to", toDate) ]

    member this.Recommendation symbol =
        this._request<Recommendation> "stock/recommendation?" [ ("symbol", symbol) ]

    member this.EarningCalendar fromDate toDate =
        this._request<EarningCalendar> "calendar/earnings?" [ ("from", fromDate); ("to", toDate) ]

    member this.Quote symbol =
        this._request<Quote> "quote?" [ ("symbol", symbol) ]
