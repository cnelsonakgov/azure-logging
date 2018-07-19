using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;
using Serilog;

namespace AzureLogging
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            Log.Information("Called directly from Serilog: Default Action.");
            Log.Information("Switching to System.Diagnostics.Trace");
            Trace.TraceInformation("Explicitly calling Trace.Information: Default Action.");

            return "Hello world ";
        }

        public string Welcome()
        {
            Log.Information("Called directly from Serilog: Welcome Method.");
            return "This is the Welcome action method.";
        }

        public string Debug()
        {
            Log.Debug("Debugging ...");
            return "This is my Debug method.";
        }

        public string Fatal()
        {
            Log.Fatal("Fatal error ...");
            return "This is my Fatal method.";
        }

        public string Verbose()
        {
            Log.Verbose("Let's be verbose ...");
            return "This is my Verbose method.";
        }

        public string Warn()
        {
            Log.Warning("Warning ...");
            return "This is my Warning method.";
        }

        public string Error()
        {
            Log.Error("An error has occurred");
            return "This is my error method.";
        }
    }
}
