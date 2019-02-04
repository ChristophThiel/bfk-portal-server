using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
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
            destination.ShiftCount = source.ShiftCount;

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
            
            foreach (var preference in source.Preferences)
            {
                if (!Enum.TryParse<PreferenceType>(preference.Type, out var type))
                    continue;
                destination.Preferences.Add(new Preference
                {
                    Avoid = preference.Avoid,
                    Type = type
                });
            }

            return destination;
        }
    }
}
