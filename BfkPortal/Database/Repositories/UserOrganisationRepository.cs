using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database.Repositories
{
    public class UserOrganisationRepository : BaseRepository, IUserOrganisationRepository
    {
        public UserOrganisationRepository(ApplicationDbContext context) : base(context) { }

        public bool Add(UserOrganisation entity)
        {
            try
            {
                Context.UserOrganisations.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.UserOrganisations.FindAsync(id);
            if (entity == null)
                return false;

            Context.UserOrganisations.Remove(entity);
            return true;
        }

        public bool Update(UserOrganisation entity)
        {
            try
            {
                Context.UserOrganisations.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserOrganisation> Find(int id)
        {
            return await Context.UserOrganisations
                .Include(uo => uo.User)
                .Include(uo => uo.Organisation)
                .FirstOrDefaultAsync(uo => uo.Id == id);
        }

        public async Task<List<UserOrganisation>> All()
        {
            return await Context.UserOrganisations
                .Include(uo => uo.User)
                .Include(uo => uo.Organisation)
                .ToListAsync();
        }
    }
}
