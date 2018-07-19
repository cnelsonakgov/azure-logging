# Azure Logging Demo

Basic MVC app to demonstrate application logging in an Azure Gov dev slot. Also includes a console app for local testing.

# Configure Serilog

This project uses the `Serilog.AspNetCore`

Configuration information can be found at the [Serilog website](https://github.com/serilog/serilog-aspnetcore). There is also a [sample application]().

## Azure Diagnostics

The Azure Diagnostic Log Stream ships events from any files in the `D:\home\LogFiles\` folder. There are some details on configuration in the [Serilog README](https://github.com/serilog/serilog-aspnetcore#writing-to-the-azure-diagnostics-log-stream).

## Sample project

A sample project can be found in the [Serilog source on GitHub](https://github.com/serilog/serilog-aspnetcore/tree/dev/samples/SimpleWebSample).

## Azure Diagnostics and Logging

[AzureAppService Provider for AspNetCore](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1#azure-app-service-provider) writes logs to file and blob storage. 

Diagnostics should be enabled in the portal and then available when using `System.Diagnostics.Trace`.

## Console Trace

To view the `console` trace use the `DebugView` application.
