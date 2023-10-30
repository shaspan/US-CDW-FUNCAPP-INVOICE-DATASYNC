using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Cdw.Azure.Function.CustomerPO
{
    public class FunctionInvoiceSync
    {
        private readonly ILogger<FunctionInvoiceSync> _logger;

        public FunctionInvoiceSync(ILogger<FunctionInvoiceSync> log)
        {
            _logger = log;
        }

        [FunctionName("Function")]
        public void Run([ServiceBusTrigger("sbt-soe-invoice-raw-poc", "sbts-soe-invoice-raw-poc", Connection = "ServiceBusConnection")]string mySbMsg)
        {
            
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
