using System;
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
