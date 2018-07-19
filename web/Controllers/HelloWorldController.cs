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

        public IActionResult Index()
        {
            Log.Information("Called directly from Serilog: Default Action.");
            Log.Information("Switching to System.Diagnostics.Trace");
            Trace.TraceInformation("Explicitly calling Trace.Information: Default Action.");
            
            string html = @"
            <p>Hello World!<p/>
            <ul>
                <li><a href='HelloWorld/Debug'>Debug</a></li>
                <li><a href='HelloWorld/Verbose'>Verbose</a></li>
                <li><a href='HelloWorld/Information'>Information</a></li>
                <li><a href='HelloWorld/Warning'>Warning</a></li>
                <li><a href='HelloWorld/Error'>Error</a></li>
                <li><a href='HelloWorld/Fatal'>Fatal</a></li>
            </ul>";

            ViewData["message"] = html;

            return View();
        }

        public string Information()
        {
            Log.Information("Called directly from Serilog: Information Method.");
            return "This is the Information action method.";
        }

        public string Debug()
        {
            Log.Debug("Debugging ...");
            return "This is the Debug method.";
        }

        public string Fatal()
        {
            Log.Fatal("Fatal error ...");
            return "This is the Fatal method.";
        }

        public string Verbose()
        {
            Log.Verbose("Let's be verbose ...");
            return "This is the Verbose method.";
        }

        public string Warning()
        {
            Log.Warning("Warning ...");
            return "This is the Warning method.";
        }

        public string Error()
        {
            Log.Error("An error has occurred");
            return "This is the error method.";
        }
    }
}
