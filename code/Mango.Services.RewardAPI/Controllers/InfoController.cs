using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.RewardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet("about")]
        public IActionResult Info()
        {
            var apiName = "RewardAPI";
            var apiVersion = "0.1";
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return Ok(new { 
                apiName,
                environmentName,
                apiVersion,
                Environment.MachineName, 
                Environment.OSVersion, 
                Environment.ProcessorCount,
                Environment.SystemDirectory,
                Environment.UserName,
                Environment.Version,
                Environment.CurrentDirectory,
                Environment.CurrentManagedThreadId,
                Environment.Is64BitOperatingSystem,
                Environment.Is64BitProcess,
                Environment.ProcessId,
                Environment.ProcessPath,
            });
        }
    }
}
