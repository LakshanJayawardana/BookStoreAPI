using BookStoreAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenProviderService _tokenProviderService;
        public AuthController(TokenProviderService tokenProviderService)
        {
            _tokenProviderService = tokenProviderService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }
            if (model.UserName == "johndoe" && model.Password == "def@123")
            {
                var token = _tokenProviderService.GenerateToken(model.UserName);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
