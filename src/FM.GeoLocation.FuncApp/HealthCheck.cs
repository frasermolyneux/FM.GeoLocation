using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FM.GeoLocation.FuncApp
{
    public static class HealthCheck
    {
        [FunctionName("HealthCheck")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequest req, ILogger log)
        {
            log.LogDebug("HealthCheck - OK");
            return new OkObjectResult("HealthCheck - OK");
        }
    }
}