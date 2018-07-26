using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Encodings.Web;


namespace AzureLogging
{
    public class LoggerController : Controller
    {
        private readonly ILogger _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            _logger.LogInformation("LoggerController: Using ILogger LoggerController");
            System.Diagnostics.Trace.TraceError("LoggerController: Using System.Diagnostics.Trace");
            return("Basic controller with log interface.");
        }
    }
}