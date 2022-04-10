using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FactIO.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class VersionController : Controller
    {
        [HttpGet]
        public IActionResult GetCurrentVersion()
        {
            var version = new { software = "FactIO Api", version = "1.0" };
            return Ok(version);
        }
    }
}
