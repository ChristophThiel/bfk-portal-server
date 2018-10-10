using System.Collections.Generic;
using System.Linq;
using BfkPortal.Core.Models;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<string> Entitlements { get; set; }

        public IEnumerable<OrganisationDto> Memberships { get; set; }

        public UserDto(User u, IEnumerable<string> entitlements)
        {
            Id = u.Id;
            Firstname = u.Firstname;
            Lastname = u.Lastname;
            Email = u.Email;
            IsDeleted = u.IsDeleted;
            Entitlements = entitlements;
            Memberships = u.Memberships?.Select(m => new OrganisationDto(m.Organisation));
        }
    }
}
