using System.Linq;
using BfkPortal.Database.Interfaces;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class AuthenticationRepository : DefaultRepository, IAuthenticationRepository
    {
        public AuthenticationRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public User Verify(string email, string password)
        {
            var userRoles = Context.UserRoles.Include(ur => ur.User)
                .Include(ur => ur.Role);

            var result = !userRoles.Any()
                ? null
                : userRoles.FirstOrDefault(ur =>
                    DefaultHashingService.VerifyPassword(email, ur.User.Password, password, ur.User.Salt,
                        Configuration["Pepper"]));

            return result?.User;

            /*var test = Context.UserRoles.Include(ur => ur.User)
                .Include(ur => ur.Role);
            var users = Context.Users.Include(u => u.Roles);
            return !users.Any() ? 
                null : 
                Enumerable.FirstOrDefault(users, user => DefaultHashingService.VerifyPassword(email, user.Password, password, user.Salt, Configuration["Pepper"]));*/
        }

        //  TODO Remove
        public void Reset()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }
    }
}
