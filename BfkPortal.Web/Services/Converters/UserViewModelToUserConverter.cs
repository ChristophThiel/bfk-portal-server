using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services.Converters
{
    public class UserViewModelToUserConverter : IConverter<UserViewModel, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserViewModelToUserConverter(IUnitOfWork unitOfWork, UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> Convert(UserViewModel source)
        {
            User destination = await _userManager.FindByIdAsync(source.Id.ToString());
            if (destination == null)
                destination = new User();

            destination.Firstname = source.Firstname;
            destination.Lastname = source.Lastname;
            destination.Email = destination.Email;
            destination.IsDeleted = destination.IsDeleted;
            
            var validRoles = source.Entitlements.Where(roleName => _roleManager.RoleExistsAsync(roleName).Result);
            await _userManager.AddToRolesAsync(destination, validRoles);

            foreach (var membershipId in source.Memberships)
            {
                destination.Memberships.Add(new Membership
                {
                    User = destination,
                    Organisation = await _unitOfWork.Organisations.FindAsync(membershipId)
                });
            }

            return destination;
        }
    }
}
