using kcs.Blog.Abstraction.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace kcs.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpGet("")]
        public IActionResult Authenticate(string name, string password)
        {
            var token = jWTAuthenticationManager.Authenticate(name, password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
