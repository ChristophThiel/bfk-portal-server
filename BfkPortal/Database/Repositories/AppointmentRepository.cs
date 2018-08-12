using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AppointmentRepository : DefaultRepository, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task Add(Appointment appointment) => await Context.Appointments.AddAsync(appointment);

        public async Task<IEnumerable<AppointmentDto>> All(int userId)
        {
            return await Task<IEnumerable<AppointmentDto>>.Factory.StartNew(() => Context.Users.Find(userId).Appointments.Select(a => new AppointmentDto
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
                    Roles = a.Owner.Roles.Select(r => r.Role.Name).ToList()
                }
            }));
        }
    }
}
