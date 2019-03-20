using Microsoft.AspNetCore.Mvc;

namespace Supermarket.V1.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "This is about Api Version 1.0" });
        }
    }
}