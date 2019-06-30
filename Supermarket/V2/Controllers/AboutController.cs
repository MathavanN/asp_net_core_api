using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.AccessPolicy;
using Supermarket.ApiResponse;
using System.Threading.Tasks;

namespace Supermarket.V2.Controller
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AboutController : ControllerBase
    {
        private IAuthorizationService _authorization;

        public AboutController(IAuthorizationService authorizationService)
        {
            _authorization = authorizationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(new { message = "This is about Api Version 2.0" });
        }

        [HttpGet]
        [Route("ForAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAdminUserInfo()
        {
            var allowed = await _authorization.AuthorizeAsync(User, nameof(Policy.Admin));
            if (!allowed.Succeeded)
                return StatusCode(StatusCodes.Status403Forbidden, new ForbiddenResponse("You don't have permission to access"));

            return Ok(new { message = "Admin user info" });
        }

        [HttpGet]
        [Route("ForCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetCustomerUserInfo()
        {
            var allowed = await _authorization.AuthorizeAsync(User, nameof(Policy.Customer));
            if (!allowed.Succeeded)
                return StatusCode(StatusCodes.Status403Forbidden, new ForbiddenResponse("You don't have permission to access"));

            return Ok(new { message = "Customer user info" });
        }

        [HttpGet]
        [Route("ForAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserInfo()
        {
            return Ok(new { message = "Admin/ Customer user info" });
        }
    }
}