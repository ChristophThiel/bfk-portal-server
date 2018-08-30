using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public bool Add(Role entity)
        {
            try
            {
                Context.Roles.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.Roles.FindAsync(id);
            if (entity == null)
                return false;

            Context.Roles.Remove(entity);
            return true;
        }

        public bool Update(Role entity)
        {
            try
            {
                Context.Roles.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Role> Find(int id) =>
            await Context.Roles.FindAsync(id);

        public async Task<List<Role>> All()
        {
            return await Context.Roles
                .Include(r => r.Users)
                .ToListAsync();
        }
    }
}
