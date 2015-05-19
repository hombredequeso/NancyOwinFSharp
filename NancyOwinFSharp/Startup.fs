namespace NancyOwinFSharp

open Owin
open Microsoft.Owin

type Startup() =
    member x.Configuration(app: Owin.IAppBuilder) =
        app.UseNancy() |> ignore

