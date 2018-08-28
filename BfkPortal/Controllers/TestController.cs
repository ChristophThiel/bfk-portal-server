using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Database;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

            var appointmentTypes = new[]
            {
                new AppointmentType {Name = "Termin"},
                new AppointmentType {Name = "Vollversammlung"},
                new AppointmentType {Name = "Dienst"},
                new AppointmentType {Name = "Übung"},
                new AppointmentType {Name = "Bewerb"}
            };
            await _context.AppointmentTypes.AddRangeAsync(appointmentTypes);  

            var appointments = new[]
            {
                new Appointment
                {
                    Title = "Example appointment",
                    Description = "This is a exaple description",
                    From = DateTime.UtcNow,
                    To = DateTime.UtcNow.AddDays(3),
                    Type = appointmentTypes.First(),
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
                    Type = appointmentTypes.Last(),
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

        [HttpGet("users")]
        public async Task<IEnumerable<UserDto>> Users()
        {
            return await Task<IEnumerable<UserDto>>.Factory.StartNew(() =>
            {
                return _context.Users.Include(u => u.Roles)
                    .Include(u => u.Organisations)
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        Firstname = u.Firstname,
                        Lastname = u.Lastname,
                        Email = u.Email,
                        IsDeleted = u.IsDeleted,
                        Roles = u.Roles.Select(r => r.Role.Name).ToList(),
                        Organisations = u.Organisations.Select(uo => new OrganisationDto
                        {
                            Id = uo.Organisation.Id,
                            Name = uo.Organisation.Name,
                            IsDeleted = uo.Organisation.IsDeleted
                        }).ToList()
                    });
            });
        }

        [HttpGet("appointments")]
        public async Task<IEnumerable<AppointmentDto>> Appointments()
        {
            return await Task<IEnumerable<AppointmentDto>>.Factory.StartNew(() =>
            {
                return _context.Appointments.Include(a => a.Participants)
                    .Include(a => a.Owner)
                    .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    From = a.From.ToString("O"),
                    To = a.To.ToString("O"),
                    Type = a.Type.Name,
                    MaxParticipants = a.MaxParticipants,
                    ShowParticipants = a.ShowParticipants,
                    Deadline = a.Deadline,
                    IsVisible = a.IsVisible,
                    Participants = a.Participants.Select(ua => new UserDto
                    {
                        Id = ua.UserId,
                        Firstname = ua.User.Firstname,
                        Lastname = ua.User.Lastname,
                        Email = ua.User.Email,
                        IsDeleted = ua.User.IsDeleted,
                        Organisations = ua.User.Organisations.Select(uo => new OrganisationDto
                        {
                            Id = uo.Organisation.Id,
                            Name = uo.Organisation.Name,
                            IsDeleted = uo.Organisation.IsDeleted
                        }).ToList(),
                        Roles = ua.User.Roles.Select(r => r.Role.Name).ToList()
                    }).ToList(),
                    Owner = new UserDto
                    {
                        Id = a.Owner.Id,
                        Firstname = a.Owner.Firstname,
                        Lastname = a.Owner.Lastname,
                        Email = a.Owner.Email,
                        IsDeleted = a.Owner.IsDeleted,
                        Roles = a.Owner.Roles.Select(ur => ur.Role.Name).ToList(),
                        Organisations = a.Owner.Organisations.Select(uo => new OrganisationDto
                        {
                            Id = uo.Organisation.Id,
                            Name = uo.Organisation.Name,
                            IsDeleted = uo.Organisation.IsDeleted
                        }).ToList()
                    }
                });
            });
        }
    }
}
