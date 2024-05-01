using ApiDevBP.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDevBP.Controllers
{
    public class AuthController : Controller
    {
        private readonly IGenerateJwtToken _generateJwtToken;

        public AuthController(IGenerateJwtToken generateJwtToken)
        {
            _generateJwtToken = generateJwtToken;
        }

        [HttpPost("login")]
        public IActionResult Login(string Name)
        {   
            var token = _generateJwtToken.JwtToken(Name);
            return Ok(new { Token = token });
        }
    }
}
