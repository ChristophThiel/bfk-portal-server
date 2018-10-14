using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;

namespace BfkPortal.Web.Services.Converters
{
    public class UserViewModelToUserConverter : IConverter<UserViewModel, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserViewModelToUserConverter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Convert(UserViewModel source)
        {
            User destination = await _unitOfWork.Users.FindAsync(source.Id);
            if (destination == null)
                destination = new User();

            destination.Firstname = source.Firstname;
            destination.Lastname = source.Lastname;
            destination.Email = source.Email;
            destination.IsDeleted = source.IsDeleted.Value;
            destination.Entitlements = new List<Entitlement>();
            destination.Memberships = new List<Membership>();

            var roles = source.Entitlements.Select(e => _unitOfWork.Roles.All().Single(r => r.Name == e));
            foreach (var role in roles)
            {
                destination.Entitlements.Add(new Entitlement
                {
                    User = destination,
                    Role = role
                });
            }

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
