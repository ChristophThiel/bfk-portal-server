using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class UserOrganisationRepository : DefaultRepository, IUserOrganisationRepository
    {
        public UserOrganisationRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task Add(UserOrganisation userOrganisation) =>
            await Context.UserOrganisations.AddAsync(userOrganisation);
    }
}
