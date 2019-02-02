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
            User destination;
            if (source.Id.HasValue)
                destination = await _unitOfWork.Users.FindAsync(source.Id.Value) ?? new User();
            else
                destination = new User();

            destination.Firstname = source.Firstname;
            destination.Lastname = source.Lastname;
            destination.Telephone = source.Telephone;
            destination.Email = source.Email;

            // Password not needed

            destination.IsActivated = source.IsActivated ?? false;
            destination.IsDeleted = source.IsDeleted ?? false;

            var roles = source.Entitlements
                .Select(e => _unitOfWork.Roles.All().SingleOrDefault(r => r.Name == e))
                .Where(r => r != null);
            foreach (var role in roles)
            {
                destination.Entitlements.Add(new Entitlement
                {
                    User = destination,
                    Role = role
                });
            }

            var organisations = source.Memberships
                .Select(m => _unitOfWork.Organisations.FindAsync(m).Result)
                .Where(o => o != null);
            foreach (var organisation in organisations)
            {
                destination.Memberships.Add(new Membership
                {
                    User = destination,
                    Organisation = organisation
                });
            }

            return destination;
        }
    }
}
