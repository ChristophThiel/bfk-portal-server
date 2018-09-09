using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database.Repositories
{
    public class OrganisationRepository : BaseRepository, IOrganisationRepository
    {
        public OrganisationRepository(ApplicationDbContext context) : base(context) { }

        public bool Add(Organisation entity)
        {
            try
            {
                Context.Organisations.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.Organisations.FindAsync(id);
            if (entity == null)
                return false;

            Context.Organisations.Remove(entity);
            return true;
        }

        public bool Update(Organisation entity)
        {
            try
            {
                Context.Organisations.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Organisation> Find(int id)
        {
            return await Context.Organisations
                .Include(o => o.Members)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Organisation>> All()
        {
            return await Context.Organisations
                .Include(o => o.Members)
                .ToListAsync();
        }
    }
}
