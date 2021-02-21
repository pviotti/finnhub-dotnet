//namespace FinnhubDotNet

module FinnhubDotNet

open Hopac
open HttpFs.Client
open HttpFs.Client.Request
open System.Text.Json

open Model

type Client(key: string) =
    let key = key
    let BaseUrl = "https://finnhub.io/api/v1/"

    member _.request<'T> path (parameters: list<string * string>) =
        let baseRequest =
            createUrl Get (BaseUrl + path)
            |> queryStringItem "token" key

        parameters
        |> List.map (fun x -> queryStringItem (fst x) (snd x))
        |> List.fold (|>) baseRequest
        |> responseAsString
        |> run
        |> JsonSerializer.Deserialize<'T>

    member this.CompanyProfile(symbol: string) =
        this.request<CompanyProfile> "stock/profile2" [ ("symbol", symbol) ]


[<EntryPoint>]
let main _argv =
    let client = Client("dummy")
    let companyProfile = client.CompanyProfile "AAPL"
    printfn "%s" companyProfile.exchange
    printfn "%A" companyProfile
    0
