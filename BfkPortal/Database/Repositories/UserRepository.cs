using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
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

        public async Task Add(User user) => await Context.Users.AddAsync(user);

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

        public async Task<bool> Delete(int id)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
                return false;

            user.IsDeleted = true;
            Context.Users.Update(user);
            return true;
        }

        public async Task<bool> Update(UserUpdateRequest update)
        {
            var entity = await Context.Users.FindAsync(update.Id);
            if (entity == null)
                return false;

            entity.Firstname = update.Firstname;
            entity.Lastname = update.Lastname;
            entity.Email = update.Email;

            var hashedPassword =
                DefaultHashingService.HashPassword(entity.Email, update.Password, entity.Salt, Configuration["Pepper"]);
            entity.Password = hashedPassword;
            foreach (var role in entity.Roles)
                Context.UserRoles.Remove(role);

            foreach (var roleId in update.Roles)
            {
                var role = await Context.Roles.FindAsync(roleId);
                if (role == null) continue;

                await Context.UserRoles.AddAsync(new UserRole
                {
                    User = entity,
                    Role = role
                });
            }

            Context.Users.Update(entity);
            return true;
        }
    }
}
