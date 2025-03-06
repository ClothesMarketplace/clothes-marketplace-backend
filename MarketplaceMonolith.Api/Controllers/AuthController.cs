using Asp.Versioning;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Core.Services.User;
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
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _userService.Login(loginRequest);

            if(result.Success)
            {
                return Ok(new {token = result.Message});
            }

            return BadRequest(new {error = result.Message});
        }

        [ApiVersion("1.0")]
        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(RegistrationRequest registrationRequest)
        {
            var result = await _userService.Registration(registrationRequest);

            if (result.Success)
            {
                return Ok(new { token = result.Message });
            }

            return BadRequest(new { error = result.Message });
        }
    }
}
