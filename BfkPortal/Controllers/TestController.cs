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

            #region Roles

            var roles = new[]
            {
                new Role {Name = "UserBfk"},
                new Role {Name = "AdminBfk"},
                new Role {Name = "UserBwst"}, // 2
                new Role {Name = "ObserverBwst"},
                new Role {Name = "AdminBwst"} // 4
            };
            await _context.Roles.AddRangeAsync(roles);

            #endregion

            #region Organisations

            var organisations = new[]
            {
                new Organisation {Name = "Feuerwehr Marchtrenk", IsDeleted = false},
                new Organisation {Name = "Feuerwehr Holzhausen", IsDeleted = false},
                new Organisation {Name = "Feuerwehr Kappern", IsDeleted = false},
                new Organisation {Name = "BFK", IsDeleted = false},
                new Organisation {Name = "AFK - Wels", IsDeleted = false},
                new Organisation {Name = "BWST", IsDeleted = false}
            };
            await _context.Organisations.AddRangeAsync(organisations);

            #endregion

            #region Users

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

            var salt5 = DefaultHashingService.GenerateSalt();
            var user5 = new User
            {
                Firstname = "Martin",
                Lastname = "Niederl",
                Email = "martin.niederl@gmail.com",
                Password = DefaultHashingService.HashPassword("martin.niederl@gmail.com", "martin", salt5, pepper),
                Salt = salt5,
                IsDeleted = false
            };

            await _context.Users.AddAsync(user1);
            await _context.Users.AddAsync(user2);
            await _context.Users.AddAsync(user3);
            await _context.Users.AddAsync(user4);

            #endregion

            #region Organisations of the users

            var userOrganisations = new[]
            {
                new UserOrganisation {User = user1, Organisation = organisations[0]},
                new UserOrganisation {User = user1, Organisation = organisations[3]},
                new UserOrganisation {User = user2, Organisation = organisations[2]},
                new UserOrganisation {User = user2, Organisation = organisations[0]},
                new UserOrganisation {User = user3, Organisation = organisations[0]},
                new UserOrganisation {User = user3, Organisation = organisations[4]},
                new UserOrganisation {User = user3, Organisation = organisations[5]},
                new UserOrganisation {User = user4, Organisation = organisations[0]},
                new UserOrganisation {User = user4, Organisation = organisations[5]},
                new UserOrganisation {User = user5, Organisation = organisations[3]},
                new UserOrganisation {User = user4, Organisation = organisations[5]},
            };
            await _context.UserOrganisations.AddRangeAsync(userOrganisations);

            #endregion

            #region Roles of the users

            var userRoles = new[]
            {
                new UserRole {User = user1, Role = roles[0]},
                new UserRole {User = user2, Role = roles[0]},
                new UserRole {User = user2, Role = roles[3]},
                new UserRole {User = user3, Role = roles[1]},
                new UserRole {User = user3, Role = roles[4]},
                new UserRole {User = user4, Role = roles[0]},
                new UserRole {User = user4, Role = roles[2]},
                new UserRole {User = user5, Role = roles[2]}
            };
            await _context.UserRoles.AddRangeAsync(userRoles);

            #endregion

            #region Appointments

            var appointments = new[]
            {
                new Appointment
                {
                    Title = $"Vollversammlung {organisations[2].Name}",
                    Description = "Beginn um 18:00 Uhr!",
                    From = DateTime.UtcNow,
                    To = DateTime.UtcNow.AddDays(1),
                    Type = AppointmentTypes.Vollversammlung,
                    AreParticipantsOrganisations = true,
                    MaxParticipants = 10,
                    ShowParticipants = false,
                    Deadline = DateTime.UtcNow.AddDays(-20),
                    IsVisible = true,
                    Owner = user2
                },
                new Appointment
                {
                    Title = $"Nachtdienst {user4.Firstname} {user4.Lastname}",
                    Description = null,
                    From = DateTime.UtcNow.AddDays(10),
                    To = DateTime.UtcNow.AddDays(11),
                    Type = AppointmentTypes.Dienst,
                    AreParticipantsOrganisations = false,
                    MaxParticipants = 0,
                    ShowParticipants = false,
                    Deadline = null,
                    IsVisible = true,
                    Owner = user4
                },
                new Appointment
                {
                    Title = $"Tagdienst {user5.Firstname} {user5.Lastname}",
                    Description = null,
                    From = DateTime.Now.AddDays(10),
                    To = DateTime.Now.AddDays(11),
                    Type = AppointmentTypes.Dienst,
                    AreParticipantsOrganisations = false,
                    MaxParticipants = 0,
                    ShowParticipants = false,
                    Deadline = null,
                    IsVisible = true,
                    Owner = user5
                },
                new Appointment
                {
                    Title = $"Übung {organisations[0]}",
                    Description = "Gefährliche Stoffe Übung in der Gemeinde Marchtrenk.",
                    From = DateTime.Now.AddDays(20),
                    To = DateTime.Now.AddDays(20),
                    Type = AppointmentTypes.Übung,
                    AreParticipantsOrganisations = true,
                    MaxParticipants = 5,
                    ShowParticipants = true,
                    Deadline = DateTime.Now.AddDays(3),
                    IsVisible = true,
                    Owner = user1
                },
                new Appointment
                {
                    Title = $"Weiterbildung {organisations[5]}",
                    Description = "Erklärung des Programms BFK - Portal: Verwaltung auf Bezirksebene.",
                    From = DateTime.Now.AddDays(2),
                    To = DateTime.Now.AddDays(2),
                    Type = AppointmentTypes.Weiterbildung,
                    AreParticipantsOrganisations = false,
                    MaxParticipants = 20,
                    ShowParticipants = true,
                    Deadline = DateTime.Now.AddDays(-8),
                    IsVisible = true,
                    Owner = user3
                },
                new Appointment
                {
                    Title = $"Funklehrgang",
                    Description = null,
                    From = DateTime.Now.AddDays(30),
                    To = DateTime.Now.AddDays(33),
                    Type = AppointmentTypes.Lehrgang,
                    AreParticipantsOrganisations = false,
                    MaxParticipants = 50,
                    ShowParticipants = false,
                    Deadline = DateTime.Now.AddDays(23),
                    IsVisible = false,
                    Owner = user3
                }
            };
            await _context.Appointments.AddRangeAsync(appointments);

            #endregion

            #region Participants of Appointments

            var appointmentUsers = new[]
            {
                new AppointmentUser {Appointment = appointments[4], User = user4},
                new AppointmentUser {Appointment = appointments[4], User = user5},
                new AppointmentUser {Appointment = appointments[5], User = user1},
                new AppointmentUser {Appointment = appointments[5], User = user2},
                new AppointmentUser {Appointment = appointments[5], User = user5},
            };
            _context.AppointmentUsers.AddRange(appointmentUsers);

            var appointmentOrganisations = new[]
            {
                new AppointmentOrganisation {Appointment = appointments[0], Organisation = user1.Organisations.ToArray()[0].Organisation},
                new AppointmentOrganisation {Appointment = appointments[0], Organisation = user3.Organisations.ToArray()[1].Organisation},
                new AppointmentOrganisation {Appointment = appointments[3], Organisation = user2.Organisations.ToArray()[0].Organisation},
            };
            _context.AppointmentOrganisations.AddRange(appointmentOrganisations);

            #endregion

            #region Offers

            var offers = new[]
            {
                new Offer
                {
                    Status = OfferStatus.Pending,
                    Receiver = user5,
                    ReceiverAppointment = appointments[2],
                    Sender = user4,
                    SenderAppointment = appointments[1]
                }
            };
            _context.Offers.AddRange(offers);

            #endregion

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
