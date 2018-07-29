using System.Security.Cryptography;
using BfkPortal.Database.Interfaces;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class UserRepository : DefaultRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }
        
        public void Add(string email, string password)
        {
            var salt = DefaultHashingService.GenerateSalt();
            var pepper = Configuration["Pepper"];

            var hashedPassword = DefaultHashingService.HashPassword(email, password, salt, pepper);
            var user = new User(email, hashedPassword, salt);
            Context.Users.Add(user);
            Save();
        }
    }
}
