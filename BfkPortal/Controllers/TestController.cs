using System.Linq;
using BfkPortal.Database;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public TestController(ApplicationDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        [HttpGet]
        public string TestConnection()
        {
            return "Everything worked fine!";
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var salt = DefaultHashingService.GenerateSalt();
            var pepper = _configuration["Pepper"];

            var email = "christoph.thiel@liwest.at";
            var password = "test";
            var hashedPassword = DefaultHashingService.HashPassword(email, password, salt, pepper);
            var user = new User
            {
                Email = email,
                Password = hashedPassword,
                Salt = salt
            };
            _context.Users.Add(user);

            var role = new Role {Name = "UserBfk"};
            _context.Roles.Add(role);
            var userRole = new UserRole
            {
                Role = role,
                User = user
            };
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = _context.Users.Include(u => u.Roles)
                .Select(u => new UserDto
                {
                    Email = u.Email,
                    Roles  = u.Roles.Select(ur => ur.Role.Name).ToList()
                });
            return Ok(result);
        }
    }
}
