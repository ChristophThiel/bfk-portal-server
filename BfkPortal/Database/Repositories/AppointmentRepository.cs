using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AppointmentRepository : DefaultRepository, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task Add(Appointment appointment) => await Context.Appointments.AddAsync(appointment);

        public async Task Delete(int id) => Context.Appointments.Remove(await Context.Appointments.FindAsync(id));

        public async Task Update(AppointmentDto appointment)
        {
            await Task.Factory.StartNew(() =>
            {
                var update = new Appointment
                {
                    Id = appointment.Id,
                    Title = appointment.Title,
                    Description = appointment.Description,
                    From = DateTime.Parse(appointment.From, null, DateTimeStyles.RoundtripKind),
                    To = DateTime.Parse(appointment.To, null, DateTimeStyles.RoundtripKind),
                };
                Context.Appointments.Update(update);
            });
        }

        public async Task<Appointment> Find(int id) =>
            await Context.Appointments.Include(a => a.Owner).FirstAsync(a => a.Id == id);

        public async Task<AppointmentType> FindType(string name) => 
            await Task.Factory.StartNew(() => Context.AppointmentTypes.First(at => at.Name == name));

        public async Task<IEnumerable<AppointmentDto>> All()
        {
            return await Task<IEnumerable<AppointmentDto>>.Factory.StartNew(() =>
                Context.Appointments.Include(a => a.Owner)
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
                    }));
        }

        public async Task<IEnumerable<string>> AllTypes() =>
            await Context.AppointmentTypes.Select(at => at.Name).ToListAsync();
    }
}
