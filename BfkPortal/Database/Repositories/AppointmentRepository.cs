using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
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
                .Include(a => a.Owner)
                .ToListAsync();
        }
    }
}
