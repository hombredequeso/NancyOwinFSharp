# NancyFx + OWIN + F#
A virtually default application, written in F#, using NancyFx and OWIN hosting.

The process for creating this project was as follows:


1. In Visual Studio (2013) install the [F# Nancy Templates](https://visualstudiogallery.msdn.microsoft.com/b55b8aac-b11a-4a6a-8a77-2153f46f4e2f)
2. Create a new, empty ASP.NET application using the Nancy FSharp application Template.
3. Use the Nuget package manager to uninstall the Nancy.Hosting package (but don’t let it uninstall the Nancy package at the same time, even though it will ask if you would like to remove that too).
4. Translate the instructions from [Hosting nancy with owin](https://github.com/NancyFx/Nancy/wiki/Hosting-nancy-with-owin) (Katana-ASP.NET Host) into F# and it will just work :-) ...
* In Package Manager Console: `Install-Package Microsoft.Owin.Host.SystemWeb`
* In Package Manager Console: `Install-Package Nancy.Owin`
* Add to web.config:
```xml
<appSettings>
    <add key="owin:HandleAllRequests" value="true"/>
</appSettings>
```
* Create an OWIN startup file called Startup.fs:
```fsharp
namespace NancyOwinFSharp

open Owin
open Microsoft.Owin

type Startup() =
    member x.Configuration(app: Owin.IAppBuilder) =
        app.UseNancy() |> ignore
```
* Remove Bootstrapper.fs

5. To host the application in Azure, deploying the Visual Studio solution from github, the NancyOwinFSharp.fsproj file, adding the following (version number, v12.0, might have to be changed):

```xml
<!-- Added, as per: http://blog.ploeh.dk/2013/08/26/running-a-pure-f-web-api-on-azure-web-sites/ -->
  <Import Project="$(VSToolsPath)\WebApplications\Microsoft.WebApplication.targets" 
        Condition="'$(VSToolsPath)' != ''" />
  <Import Project="$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v12.0\WebApplications\Microsoft.WebApplication.targets" 
        Condition="true" />  
```

For further details see [Running a pure F# Web API on Azure Web Sites](http://blog.ploeh.dk/2013/08/26/running-a-pure-f-web-api-on-azure-web-sites/). 

For similar details in relation to a SignalR application see [SignalR + Nancy with F# hosted on Azure](http://kunjan.in/2014/03/28/signalr-nancy-with-f-hosted-on-azure/)

