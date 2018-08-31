using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }

        public bool Add(Appointment entity)
        {
            try
            {
                Context.Appointments.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.Appointments.FindAsync(id);
            if (entity == null)
                return false;

            Context.Appointments.Remove(entity);
            return true;
        }

        public bool Update(Appointment entity)
        {
            try
            {
                Context.Appointments.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Appointment> Find(int id)
        {
            return await Context.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Participants)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Appointment>> All()
        {
            return await Context.Appointments
                .Include(a => a.Participants)
                .ThenInclude(ua => ua.User)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .Include(a => a.Participants)
                .ThenInclude(ua => ua.User)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .Include(a => a.Owner)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .Include(a => a.Owner)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .ToListAsync();
            /*return await Context.Appointments
                .Include(a => a.Participants)
                .ThenInclude(a => a.User)
                .Include(a => a.Owner)
                .ThenInclude(a => a.Roles)
                .ThenInclude(r => r.Role)
                .Include(a => a.Owner)
                .ThenInclude(a => a.Organisations)
                .ThenInclude(o => o.Organisation)
                .ToListAsync();*/
        }

        public IEnumerable<string> Types() =>
            Enum.GetValues(typeof(AppointmentTypes))
                .Cast<AppointmentTypes>()
                .Skip(1)
                .Select(t => t.ToString());
    }
}
