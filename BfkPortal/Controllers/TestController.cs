using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User = BfkPortal.Models.User;

namespace BfkPortal.Controllers
{
    // TODO Remove this controller
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
        public async Task<IActionResult> Reset()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            var roles = new[]
            {
                new Role {Name = "UserBfk"},
                new Role {Name = "AdminBfk"},
                new Role {Name = "UserBwst"},
                new Role {Name = "ObserverBwst"},
                new Role {Name = "AdminBwst"}
            };
            await _context.Roles.AddRangeAsync(roles);

            var pepper = _configuration["Pepper"];

            var salt1 = DefaultHashingService.GenerateSalt();
            var user1 = new User
            {
                Email = "christoph.thiel@liwest.at",
                Password = DefaultHashingService.HashPassword("christoph.thiel@liwest.at", "test", salt1, pepper),
                Salt = salt1
            };

            var salt2 = DefaultHashingService.GenerateSalt();
            var user2 = new User
            {
                Email = "matthias.herzog@gmail.com",
                Password = DefaultHashingService.HashPassword("matthias.herzog@gmail.com", "asdf", salt2, pepper),
                Salt = salt2
            };

            var salt3 = DefaultHashingService.GenerateSalt();
            var user3 = new User
            {
                Email = "christoph.zimprich@gmail.com",
                Password = DefaultHashingService.HashPassword("christoph.zimprich@gmail.com", "hello", salt3, pepper),
                Salt = salt3
            };

            var salt4 = DefaultHashingService.GenerateSalt();
            var user4 = new User
            {
                Email = "alexander.koblmüller@feuerwehr-marchtrenk.at",
                Password = DefaultHashingService.HashPassword("alexander.koblmüller@feuerwehr-marchtrenk.at", "jklö", salt4, pepper),
                Salt = salt4
            };

            await _context.Users.AddAsync(user1);
            await _context.Users.AddAsync(user2);
            await _context.Users.AddAsync(user3);
            await _context.Users.AddAsync(user4);

            var userRoles = new UserRole[]
            {
                new UserRole {User = user1, Role = roles[0]},
                new UserRole {User = user1, Role = roles[3]},
                new UserRole {User = user2, Role = roles[1]},
                new UserRole {User = user3, Role = roles[1]},
                new UserRole {User = user3, Role = roles[4]},
                new UserRole {User = user4, Role = roles[2]}
            };
            await _context.UserRoles.AddRangeAsync(userRoles);

            var appointments = new[]
            {
                new Appointment
                {
                    Title = "Example appointment",
                    Description = "This is a exaple description",
                    From = DateTime.UtcNow,
                    To = DateTime.UtcNow.AddDays(3),
                    Owner = user1
                },
                new Appointment
                {
                    Title = "Another example",
                    Description = "Another example description",
                    From = DateTime.UtcNow,
                    To = DateTime.UtcNow.AddMinutes(30),
                    Owner = user3
                },
                new Appointment
                {
                    Title = "Hello, World!",
                    Description = "I'm gonna wreck it!!!",
                    From = DateTime.UtcNow,
                    To = DateTime.UtcNow.AddHours(9),
                    Owner = user2
                }
            };
            await _context.Appointments.AddRangeAsync(appointments);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserDto>> Users()
        {
            return await Task<IEnumerable<UserDto>>.Factory.StartNew(() =>
            {
                return _context.Users.Include(u => u.Roles)
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Roles = u.Roles.Select(r => r.Role.Name).ToList()
                    });
            });
        }

        [HttpGet("appointments")]
        public async Task<IEnumerable<AppointmentDto>> Appointments()
        {
            return await Task<IEnumerable<AppointmentDto>>.Factory.StartNew(() =>
            {
                return _context.Appointments.Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    From = a.From.ToString("O"),
                    To = a.To.ToString("O"),
                    Owner = new UserDto
                    {
                        Id = a.Owner.Id,
                        Email = a.Owner.Email,
                        Roles = a.Owner.Roles.Select(ur => ur.Role.Name).ToList()
                    }
                });
            });
        }
    }
}
