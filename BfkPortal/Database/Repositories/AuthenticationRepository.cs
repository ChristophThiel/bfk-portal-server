using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AuthenticationRepository : DefaultRepository, IAuthenticationRepository
    {
        public AuthenticationRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<User> Verify(string email, string password)
        {
            return await Task<User>.Factory.StartNew(() =>
                {
                    var userRoles = Context.UserRoles.Include(ur => ur.User)
                        .Include(ur => ur.Role);

                    var result = !userRoles.Any()
                        ? null
                        : userRoles.FirstOrDefault(ur =>
                            DefaultHashingService.VerifyPassword(email, ur.User.Password, password, ur.User.Salt,
                                Configuration["Pepper"]));

                    return result?.User;
                }
            );
        }
    }
}
