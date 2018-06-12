# Azure Logging Demo

Basic MVC app to demonstrate application logging in an Azure Gov dev slot.

# Configure Serilog

This project uses the `Serilog.AspNetCore`

Configuration information can be found at the [Serilog website](https://github.com/serilog/serilog-aspnetcore). There is also a [sample application]().

## Azure Diagnostics

The Azure Diagnostic Log Stream ships events from any files in the `D:\home\LogFiles\` folder. There are some deatils on configuration in the [Serilog README](https://github.com/serilog/serilog-aspnetcore#writing-to-the-azure-diagnostics-log-stream).

## Sample project

A sample project can be found in the [Serilog source on GitHub](https://github.com/serilog/serilog-aspnetcore/tree/dev/samples/SimpleWebSample).
