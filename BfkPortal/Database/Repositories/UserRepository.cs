using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class UserRepository : DefaultRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }
        
        public async Task Add(string email, string password)
        {
            var salt = DefaultHashingService.GenerateSalt();
            var pepper = Configuration["Pepper"];

            var hashedPassword = DefaultHashingService.HashPassword(email, password, salt, pepper);
            var user = new User
            {
                Email = email,
                Password = hashedPassword,
                Salt = salt
            };
            await Context.Users.AddAsync(user);

            await Context.UserRoles.AddAsync(new UserRole
            {
                Role = Context.Roles.First(),
                User = user
            });
        }

        public async Task<User> GetById(int id) => await Task.Factory.StartNew(() => Context.Users.Include(u => u.Roles).ThenInclude(u => u.Role).First(u => u.Id == id));
    }
}
