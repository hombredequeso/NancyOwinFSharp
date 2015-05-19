namespace NancyOwinFSharp

open Nancy

open Microsoft.FSharp.Data.TypeProviders

type MercuryDb = SqlDataConnection<ConnectionStringName = @"MercuryDb">

type IndexModule() as x =
    inherit NancyModule()
    do x.Get.["/"] <- fun _ -> box x.View.["index"]

    do x.Get.["/dbtest"] <- fun _ ->
        
        use dbContext = MercuryDb.GetDataContext()
        let agentBookingStatusTable = dbContext.AgentBookingStatus

        let statusQuery = query {
            for row in agentBookingStatusTable do
            select row
        }

        let statuses = statusQuery |> Seq.toList
        let response = x.Response.AsJson(statuses)
        response :> obj

