using Asp.Versioning;
using MarketplaceMonolith.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceMonolith.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [ApiVersion("1.0")]
        [HttpGet("/getUserName")]
        public async Task<ActionResult> apiTest()
        {
            var userName = await _userService.getUserName();

            if (userName == null)
            {
                return NotFound(new { error = "Name was not found." });
            }

            return Ok(new { userName });
        }
    }
}
