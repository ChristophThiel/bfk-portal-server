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
using SQLitePCL;

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

        public async Task<IEnumerable<AppointmentDto>> All(int userId)
        {
            var owner = await Context.Users.Include(u => u.Roles).FirstAsync(u => u.Id == userId);

            return await Task<IEnumerable<AppointmentDto>>.Factory.StartNew(() =>
             Context.Appointments.Where(a => a.Owner.Id == userId)
                .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    From = a.From.ToString("O"),
                    To = a.To.ToString("O"),
                    Owner = new UserDto
                    {
                        Id = owner.Id,
                        Email = owner.Email,
                        Roles = owner.Roles.Select(ur => ur.Role.Name).ToList()
                    }
                }));
        }
    }
}
