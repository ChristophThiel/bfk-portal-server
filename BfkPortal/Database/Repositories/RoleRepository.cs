using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class RoleRepository : DefaultRepository, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<Role> Find(int id) => await Context.Roles.FindAsync(id);

        public async Task<IEnumerable<Role>> All() => await Context.Roles.ToListAsync();
    }
}
