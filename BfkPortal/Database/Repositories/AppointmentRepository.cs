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
                .Include(a => a.UserParticipants)
                .Include(a => a.OrganisationParticipants)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Appointment>> All()
        {
            return await Context.Appointments
                .Include(a => a.UserParticipants)
                .ThenInclude(au => au.User)
                .ThenInclude(au => au.Roles)
                .ThenInclude(ur => ur.Role)
                .Include(a => a.UserParticipants)
                .ThenInclude(au => au.User)
                .ThenInclude(au => au.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .Include(a => a.OrganisationParticipants)
                .ThenInclude(ao => ao.Organisation)
                .Include(a => a.Owner)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .Include(a => a.Owner)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .ToListAsync();
        }

        public List<string> Types() =>
            Enum.GetValues(typeof(AppointmentTypes))
                .Cast<AppointmentTypes>()
                .Select(t => t.ToString())
                .ToList();
    }
}
