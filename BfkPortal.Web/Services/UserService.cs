using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Security;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class UserService //: GenericService<User, UserViewModel, UserDto>, IUserService
    {
        /*public UserService(ModelStateDictionary modelState) : base(modelState) { }

        public override IEnumerable<UserDto> All()
        {
            var users = UnitOfWork.Users.All();
            foreach (var user in users)
            {
                UnitOfWork.Users.LoadCollectionAsync(user, nameof(user.Entitlements));
                foreach (var entitlement in user.Entitlements)
                    UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));
                UnitOfWork.Users.LoadCollectionAsync(user, nameof(user.Memberships));
                foreach (var membership in user.Memberships)
                    UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));
            }

            return users.Select(u => new UserDto(u));
        }

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
                IsDeleted = viewModel.IsDeleted ?? false,
                Entitlements = new List<Entitlement>(),
                Memberships = new List<Membership>(),
                Participations = new List<Participation>()
            };

            var password = hasher.HashPassword(entity, viewModel.Password);
            entity.Password = password;

            foreach (var roleName in viewModel.Entitlements)
            {
                var role = UnitOfWork.Roles.All()
                    .FirstOrDefault(r => r.Name == roleName);
                if (role == null)
                    ModelState.AddModelError("Role", $"A role with the name {roleName} does not exist!");
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
        }*/
    }
}
