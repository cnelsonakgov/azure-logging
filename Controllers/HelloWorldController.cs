using Microsoft.AspNetCore.Mvc;
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
            Log.Fatal("Called directly from Serilog: Default Action.");
            return "Hello world ";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name)
        {
            Log.Debug("Called directly from Serilog: Welcome Method.");
            return HtmlEncoder.Default.Encode($"This is the Welcome action method. Welcome {name}!");
        }

        public string Error()
        {
            Log.Verbose("An error has occurred");
            return "This is my error method.";
        }
    }
}