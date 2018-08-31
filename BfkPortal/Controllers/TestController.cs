using System;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database;
using BfkPortal.Models;
using BfkPortal.Models.Enums;
using BfkPortal.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Controllers
{
    // TODO Remove this controller
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public TestController(ApplicationDbContext context, IConfiguration configuration, IHostingEnvironment environment)
        {
            this._context = context;
            this._configuration = configuration;
            this._environment = environment;
        }

        [HttpGet]
        public string TestConnection() =>  "Everything worked fine!";

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

            var organisations = new[]
            {
                new Organisation {Name = "Feuerwehr Marchtrenk", IsDeleted = false},
                new Organisation {Name = "BWST", IsDeleted = false}
            };
            await _context.Organisations.AddRangeAsync(organisations);

            var pepper = _configuration["Pepper"];

            var salt1 = DefaultHashingService.GenerateSalt();
            var user1 = new User
            {
                Firstname = "Christoph",
                Lastname = "Thiel",
                Email = "christoph.thiel@liwest.at",
                Password = DefaultHashingService.HashPassword("christoph.thiel@liwest.at", "test", salt1, pepper),
                Salt = salt1,
                IsDeleted = false
            };

            var salt2 = DefaultHashingService.GenerateSalt();
            var user2 = new User
            {
                Firstname = "Matthias",
                Lastname = "Herzog",
                Email = "matthias.herzog@gmail.com",
                Password = DefaultHashingService.HashPassword("matthias.herzog@gmail.com", "asdf", salt2, pepper),
                Salt = salt2,
                IsDeleted = false
            };

            var salt3 = DefaultHashingService.GenerateSalt();
            var user3 = new User
            {
                Firstname = "Christoph",
                Lastname = "Zimprich",
                Email = "christoph.zimprich@gmail.com",
                Password = DefaultHashingService.HashPassword("christoph.zimprich@gmail.com", "hello", salt3, pepper),
                Salt = salt3,
                IsDeleted = false
            };

            var salt4 = DefaultHashingService.GenerateSalt();
            var user4 = new User
            {
                Firstname = "Alexander",
                Lastname = "Koblmüller",
                Email = "alexander.koblmüller@feuerwehr-marchtrenk.at",
                Password = DefaultHashingService.HashPassword("alexander.koblmüller@feuerwehr-marchtrenk.at", "jklö", salt4, pepper),
                Salt = salt4,
                IsDeleted = false
            };

            await _context.Users.AddAsync(user1);
            await _context.Users.AddAsync(user2);
            await _context.Users.AddAsync(user3);
            await _context.Users.AddAsync(user4);

            var userOrganisations = new[]
            {
                new UserOrganisation {User = user1, Organisation = organisations.First()},
                new UserOrganisation {User = user2, Organisation = organisations.First()},
                new UserOrganisation {User = user3, Organisation = organisations.First()},
                new UserOrganisation {User = user3, Organisation = organisations.Last()},
                new UserOrganisation {User = user4, Organisation = organisations.Last()}
            };
            await _context.UserOrganisations.AddRangeAsync(userOrganisations);

            var userRoles = new[]
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
                    Type = AppointmentTypes.Vollversammlung,
                    MaxParticipants = 4,
                    ShowParticipants = false,
                    Deadline = DateTime.UtcNow.AddDays(-3),
                    IsVisible = true,
                    Owner = user1
                },
                new Appointment
                {
                    Title = "Nachtdienst Alexander Koblmüller",
                    From = DateTime.UtcNow,
                    To = DateTime.UtcNow.AddDays(1),
                    Type = AppointmentTypes.Dienst,
                    MaxParticipants = 1,
                    ShowParticipants = true,
                    IsVisible = true,
                    Owner = user3
                }
            };
            await _context.Appointments.AddRangeAsync(appointments);

            var userAppointments = new[]
            {
                new UserAppointment {User = user1, Appointment = appointments.First()},
                new UserAppointment {User = user2, Appointment = appointments.First()},
                new UserAppointment {User = user4, Appointment = appointments.Last()}
            };
            await _context.UserAppointments.AddRangeAsync(userAppointments);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("mail")]
        public IActionResult Mail()
        {
            var result = DefaultMailService.SendUserAddMessage("christoph.thiel@liwest.at", "Christoph","Thiel", "test", _environment.WebRootPath);
            return Ok();
        }
    }
}
