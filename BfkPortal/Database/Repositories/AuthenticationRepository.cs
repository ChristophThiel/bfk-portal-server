using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {
        public AuthenticationRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<User> Verify(string email, string password)
        {
            var users = Context.Users
                .Include(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)
                .Where(u => u.Email == email);

            var result = !await users.AnyAsync()
                ? null
                : await users.FirstOrDefaultAsync(u => DefaultHashingService.VerifyPassword(email, u.Password, password, u.Salt, Configuration["Pepper"]));

            return result;
        }
    }
}
