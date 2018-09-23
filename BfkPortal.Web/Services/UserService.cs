using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Security;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class UserService : GenericService<User, UserViewModel, UserDto>, IUserService
    {
        public UserService(ModelStateDictionary modelState) : base(modelState) { }
        
        public override IEnumerable<UserDto> All() => UnitOfWork.Users.All().Select(u => new UserDto(u));

        public override async Task<User> CastViewModelToModel(UserViewModel viewModel)
        {
            var hasher = new Pbkdf2PasswordHasher();
            var salt = hasher.GenerateSalt();

            var entity = new User
            {
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname,
                Email = viewModel.Email,
                Salt = salt,
                IsDeleted = viewModel.IsDeleted ?? false
            };

            var password = hasher.HashPassword(entity, viewModel.Password);
            entity.Password = password;

            foreach (var roleId in viewModel.Entitlements)
            {
                var role = await UnitOfWork.Roles.FindAsync(roleId);
                if (role == null)
                    ModelState.AddModelError("Role Id", $"A role with the id {roleId} does not exist!");
                else
                    entity.Entitlements.Add(new Entitlement
                    {
                        User = entity,
                        Role = role
                    });
            }

            foreach (var organisationId in viewModel.Memberships)
            {
                var organisation = await UnitOfWork.Organisations.FindAsync(organisationId);
                if (organisation == null)
                    ModelState.AddModelError("Organisation Id", $"An organisation with the id {organisationId} does not exist!");
                else
                    entity.Memberships.Add(new Membership
                    {
                        User = entity,
                        Organisation = organisation
                    });
            }
            
            return entity;
        }

        public IEnumerable<string> Roles() => UnitOfWork.Roles.All().Select(r => r.Name);

        public new async Task Remove(int id)
        {
            var entity = await UnitOfWork.Users.FindAsync(id);
            if (entity == null)
                ModelState.AddModelError("User Id", $"A user with the id {id} does not exist!");
            else
            {
                entity.IsDeleted = true;
                UnitOfWork.Users.Update(entity);
            }

            await UnitOfWork.SaveChangesAsync();
        }
    }
}
