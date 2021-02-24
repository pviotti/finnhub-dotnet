//namespace FinnhubDotNet

module FinnhubDotNet

open System
open System.Net.Http
open System.Net.Http.Json

open Model

type Client(key: string) =
    let key = key
    let httpClient = new HttpClient(BaseAddress = Uri("https://finnhub.io/api/v1/"))

    let joinParameters (parameters: list<string * string>) =
        parameters 
        |> List.append [("token", key)]
        |> List.map (fun x -> fst(x) + "=" + snd(x)) 
        |> String.concat "&"

    member _.request<'T> path (parameters: list<string * string>) =
        async {
            let uri = path + joinParameters(parameters)
            printfn "%s" uri
            return! httpClient.GetFromJsonAsync<'T> uri |> Async.AwaitTask
        } 

    member this.CompanyProfile(symbol: string) =
        this.request<CompanyProfile> "stock/profile2?" [ ("symbol", symbol) ]


[<EntryPoint>]
let main _argv =
    let client = Client("")
    let companyProfile = client.CompanyProfile "AAPL" |> Async.RunSynchronously
    printfn "%s" companyProfile.exchange
    printfn "%A" companyProfile
    0
