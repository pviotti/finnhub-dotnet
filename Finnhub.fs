//namespace FinnhubDotNet

open Hopac
open HttpFs.Client
open HttpFs.Client.Request

type Client(key: string) =
    let key = key
    let BaseUrl = "https://finnhub.io/api/v1/"

    let request path (parameters: list<string * string>) =
        let baseRequest =
            createUrl Get (BaseUrl + path)
            |> queryStringItem "token" key

        parameters
        |> List.map (fun x -> queryStringItem (fst x) (snd x))
        |> List.fold (|>) baseRequest
        |> responseAsString
        |> run

    member _.CompanyProfile(symbol: string) =
        request "stock/profile2" [ ("symbol", symbol) ]


[<EntryPoint>]
let main _argv =
    let client = Client("dummy")
    printfn "%s" (client.CompanyProfile "AAPL")
    0
