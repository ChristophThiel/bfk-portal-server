using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database.Repositories
{
    public class UserAppointmentRepository : BaseRepository, IUserAppointmentRepository
    {
        public UserAppointmentRepository(ApplicationDbContext context) : base(context) { }


        public bool Add(UserAppointment entity)
        {
            try
            {
                Context.UserAppointments.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.UserAppointments.FindAsync(id);
            if (entity == null)
                return false;

            Context.UserAppointments.Remove(entity);
            return true;
        }

        public bool Update(UserAppointment entity)
        {
            try
            {
                Context.UserAppointments.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserAppointment> Find(int id)
        {
            return await Context.UserAppointments
                .Include(ua => ua.User)
                .Include(ua => ua.Appointment)
                .FirstOrDefaultAsync(ua => ua.Id == id);
        }

        public async Task<List<UserAppointment>> All()
        {
            return await Context.UserAppointments
                .Include(ua => ua.User)
                .Include(ua => ua.Appointment)
                .ToListAsync();
        }
    }
}
