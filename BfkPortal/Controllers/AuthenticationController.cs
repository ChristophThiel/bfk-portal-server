using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Interfaces;
using BfkPortal.Database.Repositories;
using BfkPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthenticationRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            _repository.Reset();
            return Ok("Everything worked!");
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] CredentialsRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isValidCredentials = _repository.Verify(body.Email, body.Password);
            if (!isValidCredentials)
            {
                ModelState.AddModelError("Credentials", "Invalid email or password!");
                return BadRequest(ModelState);
            }

            var claims = new[] {new Claim(ClaimTypes.Email, body.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Issuer"], claims, null,
                DateTime.Now.AddMinutes(double.Parse(_configuration["ExpirationMinutes"])), credentials);

            return Ok(new {Token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}
