# Azure Logging Demo

Basic MVC app to demonstrate application logging in an Azure Gov dev slot. Also includes a console app for local testing.

## Configure Serilog

This project uses the `Serilog.AspNetCore` and `Serilog.Sinks.Trace`

Configuration information can be found at the [Serilog website](https://github.com/serilog/serilog-aspnetcore). There is also a [sample application]().

## Azure Diagnostics

Application diagnostics are enabled in the Azure console. Logs can go to the file system and/or blob storage. ASP.NET applications use `System.Diagnostics.Trace to log information. See [Enable Diagnostics Log](https://docs.microsoft.com/en-us/azure/app-service/web-sites-enable-diagnostic-log) for more information.

The Azure Diagnostic Log Stream ships events from any files in the `D:\home\LogFiles\` folder. There are some details on configuration in the [Serilog README](https://github.com/serilog/serilog-aspnetcore#writing-to-the-azure-diagnostics-log-stream).

It is possible to use the Serilog file sink to log directly to the Application Log folder which will allow application logging and streaming. The Application Log folder appears to have two file limit with 10MB file limit (how this is rotated is not clear) so another way to capture these logs is probably necessary for auditing.

## Sample project

A sample project can be found in the [Serilog source on GitHub](https://github.com/serilog/serilog-aspnetcore/tree/dev/samples/SimpleWebSample).

## Azure Diagnostics and Logging with DotNetCore

Logging in .Net Core has been updated and now uses a [logging API](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1).

[AzureAppService Provider for AspNetCore](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1#azure-app-service-provider) writes logs to Azure's Diagnostic Application Logs -- file system with log streaming and blob storage. 

Diagnostics should be enabled in the portal. Note that previous documentation using `System.Diagnostics.Trace` does not appear to generate Azure Diagnostic Application logs with the latest release.

## Console Trace

To view the `console` trace use the `DebugView` application which is available [here](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) from Microsoft SysInternals site.

## Microsoft Extensions Azure Logger

Required to get the logger working with Azure `Diagnostic Logs`
https://www.nuget.org/packages/Microsoft.Extensions.Logging.AzureAppServices/
