using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
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

        public async Task<User> Find(int id) => await Task.Factory.StartNew(() => Context.Users.Include(u => u.Roles).ThenInclude(u => u.Role).First(u => u.Id == id));

        public async Task<IEnumerable<UserDto>> All()
        {
            return await Context.Users.Include(u => u.Roles)
                .Include(u => u.Organisations)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    Email = u.Email,
                    IsDeleted = u.IsDeleted,
                    Roles = u.Roles.Select(ur => ur.Role.Name).ToList(),
                    Organisations = u.Organisations.Select(uo => new OrganisationDto
                    {
                        Id = uo.Organisation.Id,
                        Name = uo.Organisation.Name,
                        IsDeleted = uo.Organisation.IsDeleted
                    }).ToList()
                }).ToListAsync();
        }

        public async Task Remove(int userId)
        {
            var user = await Context.Users.FindAsync(userId);

            if (user == null)
                return;

            user.IsDeleted = true;
            Context.Users.Update(user);
        }

        public async Task Update(UserDto body)
        {
            var user = await Context.Users.FindAsync(body.Id);

            if (user == null)
                return;

            user.Firstname = body.Firstname;
            user.Lastname = body.Lastname;
            user.Email = body.Email;
        }
    }
}
