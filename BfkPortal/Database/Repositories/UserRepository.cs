using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public bool Add(User entity)
        {
            try
            {
                Context.Users.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.Users.FindAsync(id);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            Context.Users.Update(entity);
            return true;
        }

        public bool Update(User entity)
        {
            try
            {
                Context.Users.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> Find(int id)
        {
            return await Context.Users
                .Include(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .Include(u => u.Appointments)
                .ThenInclude(ua => ua.Appointment)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> All()
        {
            return await Context.Users
                .Include(u => u.Roles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.Appointments)
                .ThenInclude(ua => ua.Appointment)
                .Include(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .ToListAsync();
        }
    }
}
