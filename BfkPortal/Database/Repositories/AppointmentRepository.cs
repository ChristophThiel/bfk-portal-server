using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AppointmentRepository : DefaultRepository, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task Add(Appointment appointment) => await Context.Appointments.AddAsync(appointment);

        public async Task<bool> Delete(int id)
        {
            var user = await Context.Appointments.FindAsync(id);
            if (user == null)
                return false;

            Context.Appointments.Remove(await Context.Appointments.FindAsync(id));
            return true;
        }

        public async Task<bool> Update(AppointmentUpdateRequest appointment)
        {
            var entity = await Context.Appointments.Include(a => a.Owner)
                .Include(a => a.Participants)
                .FirstOrDefaultAsync(a => a.Id == appointment.Id);
            if (entity == null)
                return false;

            entity.Title = appointment.Title;
            entity.Description = appointment.Description;
            entity.From = DateTime.Parse(appointment.From, null, DateTimeStyles.RoundtripKind);
            entity.To = DateTime.Parse(appointment.To, null, DateTimeStyles.RoundtripKind);
            entity.Type = entity.Type;
            entity.MaxParticipants = appointment.MaxParticipants;
            entity.ShowParticipants = appointment.ShowParticipants;
            entity.Deadline = appointment.Deadline == null
                ? (DateTime?) null
                : DateTime.Parse(appointment.Deadline, null, DateTimeStyles.RoundtripKind);
            entity.IsVisible = appointment.IsVisible;

            foreach (var participant in entity.Participants)
                Context.UserAppointments.Remove(participant);

            foreach (var participant in appointment.Participants)
            {
                var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == participant);
                if (user == null) continue;

                await Context.UserAppointments.AddAsync(new UserAppointment
                {
                    User = user,
                    Appointment = entity
                });
            }

            Context.Appointments.Update(entity);
            return true;
        }

        public async Task<Appointment> Find(int id) =>
            await Context.Appointments.Include(a => a.Owner)
                .Include(a => a.Participants)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<AppointmentType> FindType(string name) =>
            await Context.AppointmentTypes.FirstOrDefaultAsync(at => at.Name == name);

        public async Task<IEnumerable<AppointmentDto>> All() =>
            await Task<IEnumerable<AppointmentDto>>.Factory.StartNew(() =>
                Context.Appointments.Include(a => a.Owner)
                    .Include(a => a.Participants)
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

        public async Task<IEnumerable<string>> AllTypes() =>
            await Context.AppointmentTypes.Select(at => at.Name)
                .DefaultIfEmpty(null)
                .ToListAsync();
    }
}
