using System;
using System.Diagnostics;
using Serilog;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Serilog logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Trace()
                .CreateLogger();
            
            try
            {
                Log.Information("Application starting ...");
                Console.WriteLine("Hello World!");
                Log.Information("Switching to System.Diagnostics.Trace");
                
                //Call Trace explicitly
                Trace.WriteLine("TRACE CUSTOM LINE");
                Trace.TraceInformation("TRACE CUSTOM INFO");
                Trace.TraceWarning("TRACE CUSTOM WARN");
                Trace.TraceError("TRACE CUSTOM ERROR");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Terminated with exception");
            }
            finally
            {
                Log.Information("Application closing ...");
                Log.CloseAndFlush();
            }
        }
    }
}
