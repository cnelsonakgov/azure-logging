using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Configuration;
using Serilog.Formatting;

namespace AzureLogging
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.AzureAppSink()
                .CreateLogger();

            try
            {
                Log.Information("Getting the motors running...");

                CreateWebHostBuilder(args)
                    .ConfigureLogging((hostingContext, logging) =>
                    {
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                    })
                    .Build()
                    .Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }

    public class AzureAppSink : ILogEventSink
    {
        private readonly ITextFormatter _textFormatter;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public AzureAppSink(ITextFormatter textFormatter)
        {
            if (textFormatter == null) throw new ArgumentNullException(nameof(textFormatter));
            _textFormatter = textFormatter;
            _logger = AzureAppLogging.CreateLogger<AzureAppSink>();
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            var sr = new StringWriter();
            _textFormatter.Format(logEvent, sr);

            var text = sr.ToString().Trim();

            if (logEvent.Level == LogEventLevel.Fatal)
                _logger.LogCritical(text);
            else if (logEvent.Level == LogEventLevel.Error)
                _logger.LogError(text);
            else if (logEvent.Level == LogEventLevel.Warning)
                _logger.LogWarning(text);
            else if (logEvent.Level == LogEventLevel.Information)
                _logger.LogInformation(text);
            else if (logEvent.Level == LogEventLevel.Debug)
                _logger.LogDebug(text);
            else
                _logger.LogTrace(text);
        }
    }

    public static class AzureAppLogging
    {
        public static ILoggerFactory LoggerFactory {get;} = new LoggerFactory().AddConsole().AddAzureWebAppDiagnostics();
        public static Microsoft.Extensions.Logging.ILogger CreateLogger<T>() =>
            LoggerFactory.CreateLogger<T>();
    }

    public static class AzureAppSinkExtensions
    {
       public static LoggerConfiguration AzureAppSink(
                this LoggerSinkConfiguration loggerConfiguration,
                ITextFormatter textFormatter = null)
        {
        return loggerConfiguration.Sink(new AzureAppSink(textFormatter));
        }
    }
}
