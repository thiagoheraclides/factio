using Microsoft.AspNetCore.Mvc;

namespace Br.Com.FactIO.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class VersionController : Controller
    {
        [HttpGet]
        public IActionResult GetCurrentVersion()
        {
            var version = new { software = "FactIO Api", version = "2.0" };
            return Ok(version);
        }
    }
}
